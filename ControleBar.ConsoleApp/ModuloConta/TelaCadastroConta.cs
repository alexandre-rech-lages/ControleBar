using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloConta
{
    internal class TelaCadastroConta : TelaBase
    {
        IRepositorioConta repositorioConta;

        IRepositorio<Mesa> repositorioMesa;
        IRepositorio<Garcom> repositorioGarcom;
        IRepositorio<Produto> repositorioProduto;

        TelaCadastroMesa telaMesa;
        TelaCadastroGarcom telaGarcom;
        TelaCadastroProduto telaProduto;

        private readonly Notificador notificador;

        public TelaCadastroConta(
            IRepositorioConta repositorioConta,

            IRepositorio<Produto> repositorioProduto,
            IRepositorio<Garcom> repositorioGarcom,
            IRepositorio<Mesa> repositorioMesa,

            Notificador notificador,

            TelaCadastroGarcom telaGarcom,
            TelaCadastroMesa telaMesa,
            TelaCadastroProduto telaProduto

            ) : base("Cadastro de Contas")
        {
            this.repositorioConta = repositorioConta;
            this.telaMesa = telaMesa;
            this.repositorioGarcom = repositorioGarcom;
            this.repositorioMesa = repositorioMesa;
            this.telaGarcom = telaGarcom;
            this.telaProduto = telaProduto;
            this.repositorioProduto = repositorioProduto;
            this.notificador = notificador;
        }

        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Abrir Nova Conta");
            Console.WriteLine("Digite 2 para Adicionar Pedidos");
            Console.WriteLine("Digite 3 para Fechar a Conta");
            Console.WriteLine("Digite 4 para Visualizar Contas Abertas");
            Console.WriteLine("Digite 5 para Visualizar Faturamento");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void AbrirNovaConta()
        {
            MostrarTitulo("Abertura de Nova Conta");

            Mesa mesaSelecionada = ObterMesa();
            if (mesaSelecionada == null)
                return;

            Garcom garcomSelecionado = ObterGarcom();
            if (garcomSelecionado == null)
                return;

            Conta conta = new Conta(mesaSelecionada, garcomSelecionado);

            SelecionarProdutos(conta);

            repositorioConta.AbrirNovaConta(conta);
        }

        public void FecharConta()
        {
            MostrarTitulo("Fechar a Conta");

            var temRegistros = VisualizarContasAbertas();

            if (temRegistros == false)
                return;

            Console.Write("Digite a mesa da Conta: ");
            int numeroMesa = Convert.ToInt32(Console.ReadLine());

            var conta = repositorioConta.SelecionarContaPorMesa(numeroMesa);

            Console.WriteLine("Informe o percentual de gorjeta: ");
            decimal percentualGorjeta = Convert.ToInt32(Console.ReadLine());

            conta.Fechar(percentualGorjeta);

            //Console.WriteLine(conta);

            notificador.ApresentarMensagem("Conta Fechada", TipoMensagem.Sucesso);
        }

        public void AdicionarPedido()
        {
            MostrarTitulo("Adicionar Pedido na Conta");

            var temRegistros = VisualizarContasAbertas();

            if (temRegistros == false)
                return;

            Console.Write("Digite a mesa do pedido: ");
            int numeroMesa = Convert.ToInt32(Console.ReadLine());

            var conta = repositorioConta.SelecionarContaPorMesa(numeroMesa);

            SelecionarProdutos(conta);
        }

        public bool VisualizarContasAbertas()
        {
            List<Conta> contas = repositorioConta.SelecionarContasAbertas();

            if (contas.Count == 0)
            {
                notificador.ApresentarMensagem("Nenhum Conta Aberta.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Conta c in contas)
            {
                Console.WriteLine(c.ToString());
            }

            Console.WriteLine();

            return true;
        }

        public void VisualizarFaturamento()
        {
            Console.WriteLine("Informe a data: ");

            DateTime data = Convert.ToDateTime(Console.ReadLine());

            List<Conta> contas = repositorioConta.SelecionarPorData(data);


            var valorFaturamento = contas.Sum(c => c.CalcularValorTotal());

            notificador.ApresentarMensagem($"Total arrecadado: {valorFaturamento}", TipoMensagem.Sucesso);

            List<GorjetaDoDia> gorjetas = repositorioConta.SelecionarGorjetas(data);

            foreach (var item in gorjetas)
            {
                Console.WriteLine(item.Garcom.Nome + " faturou " + item.Valor);
            }
        }


        #region métodos privados

        private void SelecionarProdutos(Conta conta)
        {
            Console.Write("Selecionar produtos? s/n");

            string opcao = Console.ReadLine();

            if (opcao == "s")
            {
                var temRegistros = telaProduto.VisualizarRegistros("");

                if (temRegistros == false)
                    return;
            }

            while (opcao == "s")
            {
                Produto produto = ObterProduto();

                Console.Write("Digite a quantidade: ");
                int qtd = Convert.ToInt32(Console.ReadLine());

                conta.RegistrarPedido(produto, qtd);

                notificador.ApresentarMensagem("Produto selecionado", TipoMensagem.Sucesso);

                Console.WriteLine("Selecionar mais produtos? s/n");

                opcao = Console.ReadLine();
            }
        }

        private Produto ObterProduto()
        {
            Console.Write("Digite o nº do produto: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Produto produto = repositorioProduto.SelecionarRegistro(numero);
            return produto;
        }

        private Garcom ObterGarcom()
        {
            var temRegistros = telaGarcom.VisualizarRegistros("");

            if (temRegistros == false)
                return null;

            Console.Write("Digite o Número do Garçom: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            return repositorioGarcom.SelecionarRegistro(numero);
        }

        private Mesa ObterMesa()
        {
            var temRegistros = telaMesa.VisualizarRegistros("");

            if (temRegistros == false)
                return null;

            Console.Write("Digite o Número da Mesa: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            return repositorioMesa.SelecionarRegistro(numero);
        }

        #endregion
    }
}

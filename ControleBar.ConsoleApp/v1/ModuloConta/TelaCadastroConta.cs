using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloProduto;
using System;

namespace ControleBar.ConsoleApp.ModuloConta
{
    internal class TelaCadastroConta : TelaBase
    {
        RepositorioConta repositorioConta;

        IRepositorio<Mesa> repositorioMesa;
        IRepositorio<Garcom> repositorioGarcom;
        IRepositorio<Produto> repositorioProduto;

        TelaCadastroMesa telaMesa;
        TelaCadastroGarcom telaGarcom;
        TelaCadastroProduto telaProduto;

        private readonly Notificador notificador;

        public TelaCadastroConta(
            RepositorioConta repositorioConta,

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

            //Nova Conta	Adicionar Pedidos	Fechar	Visualizar Contas Abertas	Visualizar Total Faturado Dia	Visualizar Total Gorjetas
            Console.WriteLine("Digite 1 para Nova Conta");            

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}

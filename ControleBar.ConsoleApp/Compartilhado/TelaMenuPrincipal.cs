using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloProduto;
using System;

namespace ControleBar.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {
        private readonly IRepositorio<Garcom> repositorioGarcom;
        private readonly IRepositorio<Produto> repositorioProduto;
        private readonly IRepositorio<Mesa> repositorioMesa;

        private readonly RepositorioConta repositorioConta;

        private readonly TelaCadastroGarcom telaCadastroGarcom;
        private readonly TelaCadastroProduto telaCadastroProduto;
        private readonly TelaCadastroConta telaCadastroConta;
        private readonly TelaCadastroMesa telaCadastroMesa;

        public TelaMenuPrincipal(Notificador notificador)
        {
            repositorioGarcom = new RepositorioGarcom();
            repositorioProduto = new RepositorioProduto();
            repositorioConta = new RepositorioConta();
            repositorioMesa = new RepositorioMesa();

            telaCadastroGarcom = new TelaCadastroGarcom(repositorioGarcom, notificador);
            telaCadastroProduto = new TelaCadastroProduto(repositorioProduto, notificador);
            telaCadastroMesa = new TelaCadastroMesa(repositorioMesa, notificador);
            telaCadastroConta = new TelaCadastroConta(repositorioConta, repositorioProduto, repositorioGarcom,
                repositorioMesa, notificador, telaCadastroGarcom, telaCadastroMesa, telaCadastroProduto);
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Controle de Mesas de Bar 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Gerenciar Garçons");
            Console.WriteLine("Digite 2 para Gerenciar Mesas");
            Console.WriteLine("Digite 3 para Gerenciar produtos");
            Console.WriteLine("Digite 4 para Gerenciar Contas de mesas de clientes");

            Console.WriteLine("Digite s para sair");

            string opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase ObterTela()
        {
            string opcao = MostrarOpcoes();

            TelaBase tela;

            if (opcao == "1")
                tela = telaCadastroGarcom;

            else if (opcao == "2")
                tela = telaCadastroMesa;

            else if (opcao == "3")
                tela = telaCadastroProduto;

            else if (opcao == "4")
                tela = telaCadastroConta;

            else if (opcao == "5")
                tela = null;

            else
                return ObterTela();

            return tela;
        }


    }
}

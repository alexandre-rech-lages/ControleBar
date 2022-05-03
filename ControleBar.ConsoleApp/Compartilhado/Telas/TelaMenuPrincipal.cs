using ControleBar.ConsoleApp.ModuloConta;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloProduto;
using System;

namespace ControleBar.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {
        private readonly DataContext dataContext;

        private readonly IRepositorio<Garcom> repositorioGarcom;
        private readonly IRepositorio<Produto> repositorioProduto;
        private readonly IRepositorio<Mesa> repositorioMesa;

        private readonly IRepositorioConta repositorioConta;

        private readonly TelaCadastroGarcom telaCadastroGarcom;
        private readonly TelaCadastroProduto telaCadastroProduto;
        private readonly TelaCadastroConta telaCadastroConta;
        private readonly TelaCadastroMesa telaCadastroMesa;

        public TelaMenuPrincipal()
        {
            dataContext = new DataContext();
            var notificador = new Notificador();

            repositorioGarcom = new RepositorioGarcomEmArquivo(dataContext);
            repositorioProduto = new RepositorioProdutoEmArquivo(dataContext);
            repositorioConta = new RepositorioContaEmArquivo(dataContext);
            repositorioMesa = new RepositorioMesaEmArquivo(dataContext);

            telaCadastroGarcom = new TelaCadastroGarcom(repositorioGarcom, notificador);
            telaCadastroProduto = new TelaCadastroProduto(repositorioProduto, notificador);
            telaCadastroMesa = new TelaCadastroMesa(repositorioMesa, notificador);
            telaCadastroConta = new TelaCadastroConta(repositorioConta, repositorioProduto, repositorioGarcom,
                repositorioMesa, notificador, telaCadastroGarcom, telaCadastroMesa, telaCadastroProduto);
        }

        

        private void PopularAplicacao()
        {
            repositorioGarcom.Inserir(new Garcom("José Roberto", "321654987"));
            repositorioGarcom.Inserir(new Garcom("João da Silva", "123789456"));

            repositorioProduto.Inserir(new Produto("Cerveja Original", 10));
            repositorioProduto.Inserir(new Produto("Porção de Batata", 20));
            repositorioProduto.Inserir(new Produto("Porção de Tilápia", 30));
            repositorioProduto.Inserir(new Produto("Cachaça Artesanal", 5));

            repositorioMesa.Inserir(new Mesa(1));
            repositorioMesa.Inserir(new Mesa(2));
            repositorioMesa.Inserir(new Mesa(3));
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

            Console.WriteLine("Digite s para gravar as informações e sair");

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

            else if (opcao == "s")
            {
                dataContext.GravarBinario();
                tela = null;
            }
            else
                return ObterTela();

            return tela;
        }



    }
}

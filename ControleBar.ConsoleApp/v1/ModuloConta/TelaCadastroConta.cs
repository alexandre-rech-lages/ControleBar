using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloProduto;

namespace ControleBar.ConsoleApp.ModuloMesa
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


    }
}

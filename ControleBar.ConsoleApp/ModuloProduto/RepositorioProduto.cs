using ControleBar.ConsoleApp.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    public class RepositorioProdutoEmMemoria : RepositorioEmMemoria<Produto>
    {
    }

    public class RepositorioProdutoEmArquivo : RepositorioEmArquivo<Produto>
    {
        public RepositorioProdutoEmArquivo(JsonContext jsonContext) : base(jsonContext)
        {
        }

        public override void AtualizarContador()
        {
            if (_jsonContext.Produtos.Count > 0)
                contadorId = _jsonContext.Produtos.Max(x => x.Numero);
        }

        public override List<Produto> Registros()
        {
            return _jsonContext.Produtos;
        }
    }
}

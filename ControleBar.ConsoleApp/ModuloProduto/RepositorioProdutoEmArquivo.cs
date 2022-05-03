using ControleBar.ConsoleApp.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloProduto
{

    public class RepositorioProdutoEmArquivo : RepositorioEmArquivo<Produto>
    {
        public RepositorioProdutoEmArquivo(DataContext dataContext) : base(dataContext)
        {
        }

        public override void AtualizarContador()
        {
            if (_dataContext.Produtos.Count > 0)
                contadorId = _dataContext.Produtos.Max(x => x.Numero);
        }

        public override List<Produto> ObterRegistros()
        {
            return _dataContext.Produtos;
        }
    }
}

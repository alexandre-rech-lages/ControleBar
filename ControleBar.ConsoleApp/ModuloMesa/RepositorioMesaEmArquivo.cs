using ControleBar.ConsoleApp.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloMesa
{

    public class RepositorioMesaEmArquivo : RepositorioEmArquivo<Mesa>
    {
        public RepositorioMesaEmArquivo(DataContext dataContext) : base(dataContext)
        {
        }

        public override void AtualizarContador()
        {
            if (_dataContext.Mesas.Count > 0)
                contadorId = _dataContext.Mesas.Max(x => x.Numero);
        }

        public override string Inserir(Mesa entidade)
        {
            ObterRegistros().Add(entidade);

            return "REGISTRO_VALIDO";
        }

        public override List<Mesa> ObterRegistros()
        {
            return _dataContext.Mesas;
        }
    }
}

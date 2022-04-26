using ControleBar.ConsoleApp.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    public class RepositorioMesaEmMemoria : RepositorioEmMemoria<Mesa>
    {     
        public override string Inserir(Mesa entidade)
        {
            registros.Add(entidade);

            return "REGISTRO_VALIDO";
        }
    }

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
            Registros().Add(entidade);

            return "REGISTRO_VALIDO";
        }

        public override List<Mesa> Registros()
        {
            return _dataContext.Mesas;
        }
    }
}

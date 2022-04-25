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
        public RepositorioMesaEmArquivo(JsonContext jsonContext) : base(jsonContext)
        {
        }

        public override void AtualizarContador()
        {
            if (_jsonContext.Mesas.Count > 0)
                contadorId = _jsonContext.Mesas.Max(x => x.Numero);
        }

        public override string Inserir(Mesa entidade)
        {
            Registros().Add(entidade);

            return "REGISTRO_VALIDO";
        }

        public override List<Mesa> Registros()
        {
            return _jsonContext.Mesas;
        }
    }
}

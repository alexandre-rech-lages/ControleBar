using ControleBar.ConsoleApp.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class RepositorioGarcomEmMemoria : RepositorioEmMemoria<Garcom>
    {
    }

    public class RepositorioGarcomEmArquivo : RepositorioEmArquivo<Garcom>
    {
        public RepositorioGarcomEmArquivo(JsonContext jsonContext) : base(jsonContext)
        {            
        }

        public override void AtualizarContador()
        {
            if (_jsonContext.Garcons.Count > 0)
                contadorId = _jsonContext.Garcons.Max(x => x.Numero);
        }

        public override List<Garcom> Registros()
        {
            return _jsonContext.Garcons;
        }
    }


}
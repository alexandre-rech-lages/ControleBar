using ControleBar.ConsoleApp.Compartilhado;

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
}

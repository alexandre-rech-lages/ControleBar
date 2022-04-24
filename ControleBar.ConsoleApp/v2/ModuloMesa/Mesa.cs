using ControleBar.ConsoleApp.Compartilhado;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        bool ocupada;

        public Mesa(int numero)
        {
            this.Numero = numero;
            this.ocupada = false;
        }

        public override string ToString()
        {
            string estado = ocupada ? "ocupada" : "desocupada";

            return $"Mesa: {Numero} \t esta {estado}";
        }

        public void Desocupar()
        {
            ocupada = false;
        }

        public bool EstaOcupada()
        {
            return ocupada;
        }

        public void Ocupar()
        {
            ocupada = true;
        }
    }
}

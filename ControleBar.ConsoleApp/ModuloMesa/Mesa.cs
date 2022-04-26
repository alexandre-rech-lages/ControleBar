using ControleBar.ConsoleApp.Compartilhado;
using System;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    [Serializable]
    public class Mesa : EntidadeBase<Mesa>
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

        public override void Atualizar(Mesa novaEntidade)
        {
            this.Numero = novaEntidade.Numero;
            this.ocupada = novaEntidade.ocupada;
        }
    }
}

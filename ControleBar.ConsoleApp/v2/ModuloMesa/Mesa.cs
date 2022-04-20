using ControleBar.ConsoleApp.Compartilhado;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        string nome;
        bool ocupada;

        public string Nome { get => nome; set => nome = value; }

        public Mesa(string nome)
        {
            this.Nome = nome;
            this.ocupada = false;
        }
        public override string ToString()
        {
            string aux = (ocupada) ? "sim" : "Nao";
            return $"Nº Mesa: {Numero}\nNome : {Nome}\n Esta ocupada: {aux}";
        }
        public void desocuparMesa()
        {
            ocupada = false;
        }
        public bool LocarMesa()
        {
            if (!ocupada)
            {
                ocupada = true;
                return true;
            }
            return false;
        }
    }
}

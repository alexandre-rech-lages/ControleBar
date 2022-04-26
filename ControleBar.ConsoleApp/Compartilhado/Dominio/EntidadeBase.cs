using System;

namespace ControleBar.ConsoleApp.Compartilhado
{    
    [Serializable]
    public abstract class EntidadeBase<T>
    {
        public int Numero { get; set; }

        public abstract void Atualizar(T novaEntidade);
    }
}

using ControleBar.ConsoleApp.Compartilhado;
using System;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    [Serializable]
    public class Produto : EntidadeBase<Produto>
    {
        string nome;
        decimal preco;

        public string Nome { get => nome; }
        public decimal Preco { get => preco; }
               
        public Produto(string nome, decimal preco)
        {
            this.nome = nome;
            this.preco = preco;
        }

        public override string ToString()
        {
            return "Id: " + Numero + "\t" +
                "Nome do produto: " + Nome + "\t" +
                "Preço do produto: R$" + Preco;
        }

        public override void Atualizar(Produto novaEntidade)
        {
            this.nome = novaEntidade.nome;
            this.preco = novaEntidade.preco;
        }
    }
}

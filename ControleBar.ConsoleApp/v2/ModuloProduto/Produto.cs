using ControleBar.ConsoleApp.Compartilhado;
using System;

namespace ControleBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        string nome;
        double preco;
        int quantidade;

        public string Nome { get => nome; }
        public double Preco { get => preco; }
        public int Quantidade { get => quantidade; }

        public Produto(string nome, double preco, int quantidade)
        {
            this.nome = nome;
            this.preco = preco;
            this.quantidade = quantidade;
        }
        public void AtualizarQuantiade(int quantidade)
        {
            this.quantidade = quantidade;
        }
        public override string ToString()
        {
            return "Id: " + Numero + Environment.NewLine +
                "Nome do produto: " + Nome + Environment.NewLine +
                "Preço do produto: R$" + Preco + Environment.NewLine +
                "Quantidade do produto: R$" + Quantidade + Environment.NewLine;
        }
    }
}

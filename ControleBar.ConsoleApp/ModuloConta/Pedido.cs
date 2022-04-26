using ControleBar.ConsoleApp.ModuloProduto;
using System;

namespace ControleBar.ConsoleApp.ModuloConta
{
    [Serializable]
    public class Pedido
    {
       
        public Pedido(Produto produto, int qtd)
        {
            Produto = produto;
            Qtd = qtd;
        }

        public Produto Produto { get; }
        public int Qtd { get; }

        public decimal CalcularValor()
        {
            return Qtd * Produto.Preco;
        }

        public override string ToString()
        {
            return
                "Produto: " + Produto.Nome + "\t" +
                "Quantidade: " + Qtd + "\t" +
                "Valor: " + CalcularValor();
        }
    }
}

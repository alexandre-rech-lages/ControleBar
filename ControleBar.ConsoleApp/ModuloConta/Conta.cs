using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloConta
{
    [Serializable]
    public class Conta : EntidadeBase<Conta>
    {
        private List<Pedido> pedidos;

        
        public Conta(Mesa mesaSelecionada, Garcom garcomSelecionado)
        {
            MesaSelecionada = mesaSelecionada;
            GarcomSelecionado = garcomSelecionado;
            pedidos = new List<Pedido>();
            Data = DateTime.Now.Date;
            Abrir();
        }

        private void Abrir()
        {
            MesaSelecionada.Ocupar();
            Aberta = true;
        }

        internal bool EstaFechada()
        {
            return Aberta == false;
        }

        public Mesa MesaSelecionada { get; private set; }
        public Garcom GarcomSelecionado { get; private set; }
        public List<Pedido> Pedidos { get { return pedidos; } }
        public DateTime Data { get; private set; }

        public decimal ValorGorjeta { get; private set; }

        public bool Aberta { get; private set; }

        internal void RegistrarPedido(Produto produto, int qtd)
        {
            pedidos.Add(new Pedido(produto, qtd));
        }

        public override string ToString()
        {
            return
                "Mesa: " + MesaSelecionada.Numero + "\t" +
                "Garçom: " + GarcomSelecionado.Nome + "\t" +
                "Valor Consumido: " + CalcularValorConsumido();
        }

        public decimal CalcularValorTotal()
        {
            return CalcularValorConsumido() + ValorGorjeta;
        }

        public decimal CalcularValorConsumido()
        {
            return pedidos.Sum(p => p.CalcularValor());
        }

        public void Fechar(decimal percentualGorjeta)
        {
            var valorConsumido = CalcularValorConsumido();
            ValorGorjeta = valorConsumido * (percentualGorjeta / 100m);

            GarcomSelecionado.RegistrarAtendimento(this);

            MesaSelecionada.Desocupar();

            Aberta = false;
        }

        public override void Atualizar(Conta novaEntidade)
        {
            MesaSelecionada = novaEntidade.MesaSelecionada;
            GarcomSelecionado = novaEntidade.GarcomSelecionado;
            Data = novaEntidade.Data;
        }
    }
}

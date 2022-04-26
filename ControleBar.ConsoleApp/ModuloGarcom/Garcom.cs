using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloConta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    [Serializable]
    public class Garcom : EntidadeBase<Garcom>
    {
        private List<Conta> contasAtendidas;
        public string Nome { get; set; }
        public string CPF { get; set; }
        public double Gorjeta { get; set; }

        public Garcom()
        {

        }
        public Garcom(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
            contasAtendidas = new List<Conta>();
        }

        public override string ToString()
        {
            return "Nº: " + Numero + "\t" +
                "Nome do garçom: " + Nome;
        }

        public void RegistrarAtendimento(Conta conta)
        {
            contasAtendidas.Add(conta);
        }

        public decimal CalcularGorgetaDoDia(DateTime hoje)
        {
            return contasAtendidas
                .Where(c => c.Data.Equals(hoje.Date))
                .Sum(c => c.ValorGorjeta);
        }

        public override void Atualizar(Garcom novaEntidade)
        {
            Nome = novaEntidade.Nome;
            CPF = novaEntidade.CPF;
        }
    }
}

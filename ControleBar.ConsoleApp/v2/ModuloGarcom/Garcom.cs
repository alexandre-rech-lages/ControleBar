﻿using ControleBar.ConsoleApp.Compartilhado;
using System;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public double Gorjeta { get; set; }

        public Garcom(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
            Gorjeta = 0;
        }

        public override string ToString()
        {
            return "Id: " + Numero + Environment.NewLine +
                "Nome do garçom: " + Nome + Environment.NewLine +
                "Gorjetas recebidas: R$" + Gorjeta + Environment.NewLine;
        }


    }
}
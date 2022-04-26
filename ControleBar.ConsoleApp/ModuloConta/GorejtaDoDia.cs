using ControleBar.ConsoleApp.ModuloGarcom;
using System;

namespace ControleBar.ConsoleApp.ModuloConta
{

    [Serializable]
    public class GorjetaDoDia
    {
       
        public GorjetaDoDia(DateTime data, Garcom garcom)
        {
            Garcom = garcom;
            Valor = garcom.CalcularGorgetaDoDia(data);
        }

        public Garcom Garcom { get; private set; }

        public decimal Valor { get; private set; }

    }
}

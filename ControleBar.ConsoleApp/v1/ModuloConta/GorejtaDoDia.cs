using ControleBar.ConsoleApp.ModuloGarcom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloConta
{
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

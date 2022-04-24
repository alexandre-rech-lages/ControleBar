using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase<Conta>
    {
        public void AbrirNovaConta(Conta conta)
        {            
            registros.Add(conta);
        }

        internal List<Conta> SelecionarContasAbertas()
        {
            return registros.Where(x => x.Aberta).ToList();
        }

        public Conta SelecionarContaPorMesa(int numeroMesa)
        {
            return registros
                .Where(x => x.Aberta == true)
                .FirstOrDefault(x => x.MesaSelecionada.Numero == numeroMesa);
        }

        internal List<Conta> SelecionarPorData(DateTime hoje)
        {        
            
            return registros
                .Where(c => c.EstaFechada())
                .Where(c => c.Data.Equals(hoje.Date))
                .ToList();
        }

        internal List<GorjetaDoDia> SelecionarGorjetas(DateTime data)
        {
            return SelecionarPorData(data)
                    .GroupBy(c => c.GarcomSelecionado)
                    .Select(x => new GorjetaDoDia(data, x.Key))
                    .ToList();           
        }
    }
}

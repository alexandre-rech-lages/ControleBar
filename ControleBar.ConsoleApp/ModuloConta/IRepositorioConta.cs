using System;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.ModuloConta
{
    public interface IRepositorioConta
    {
        void AbrirNovaConta(Conta conta);
        Conta SelecionarContaPorMesa(int numeroMesa);
        List<GorjetaDoDia> SelecionarGorjetas(DateTime data);
        List<Conta> SelecionarPorData(DateTime hoje);
        List<Conta> SelecionarContasAbertas();
    }
}

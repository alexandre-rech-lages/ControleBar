using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;

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

    public class RepositorioContaEmMemoria : RepositorioEmMemoria<Conta>, IRepositorioConta
    {
        public void AbrirNovaConta(Conta conta)
        {
            base.Inserir(conta);
        }

        public List<Conta> SelecionarContasAbertas()
        {
            return registros.Where(x => x.Aberta).ToList();
        }

        public Conta SelecionarContaPorMesa(int numeroMesa)
        {
            return registros
                .Where(x => x.Aberta == true)
                .FirstOrDefault(x => x.MesaSelecionada.Numero == numeroMesa);
        }

        public List<Conta> SelecionarPorData(DateTime hoje)
        {

            return registros
                .Where(c => c.EstaFechada())
                .Where(c => c.Data.Equals(hoje.Date))
                .ToList();
        }

        public List<GorjetaDoDia> SelecionarGorjetas(DateTime data)
        {
            return SelecionarPorData(data)
                    .GroupBy(c => c.GarcomSelecionado)
                    .Select(x => new GorjetaDoDia(data, x.Key))
                    .ToList();
        }
    }

    public class RepositorioContaEmArquivo : RepositorioEmArquivo<Conta>, IRepositorioConta
    {
        public RepositorioContaEmArquivo(JsonContext jsonContext) : base(jsonContext)
        {
        }

        public override void AtualizarContador()
        {
            if (_jsonContext.Contas.Count > 0)
                contadorId = _jsonContext.Contas.Max(x => x.Numero);
        }

        public void AbrirNovaConta(Conta conta)
        {
            conta.Numero = ++contadorId;

            Registros().Add(conta);
        }

        public List<Conta> SelecionarContasAbertas()
        {
            return Registros().Where(x => x.Aberta).ToList();
        }

        public Conta SelecionarContaPorMesa(int numeroMesa)
        {
            return Registros()
                .Where(x => x.Aberta == true)
                .FirstOrDefault(x => x.MesaSelecionada.Numero == numeroMesa);
        }

        public List<Conta> SelecionarPorData(DateTime hoje)
        {

            return Registros()
                .Where(c => c.EstaFechada())
                .Where(c => c.Data.Equals(hoje.Date))
                .ToList();
        }

        public List<GorjetaDoDia> SelecionarGorjetas(DateTime data)
        {
            return SelecionarPorData(data)
                    .GroupBy(c => c.GarcomSelecionado)
                    .Select(x => new GorjetaDoDia(data, x.Key))
                    .ToList();
        }

        public override List<Conta> Registros()
        {
            return _jsonContext.Contas;
        }
    }
}

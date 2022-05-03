using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloConta
{

    public class RepositorioContaEmArquivo : RepositorioEmArquivo<Conta>, IRepositorioConta
    {
        public RepositorioContaEmArquivo(DataContext dataContext) : base(dataContext)
        {
        }

        public override void AtualizarContador()
        {
            if (_dataContext.Contas.Count > 0)
                contadorId = _dataContext.Contas.Max(x => x.Numero);
        }

        public void AbrirNovaConta(Conta conta)
        {
            conta.Numero = ++contadorId;

            ObterRegistros().Add(conta);
        }

        public List<Conta> SelecionarContasAbertas()
        {
            return ObterRegistros().Where(x => x.Aberta).ToList();
        }

        public Conta SelecionarContaPorMesa(int numeroMesa)
        {
            return ObterRegistros()
                .Where(x => x.Aberta == true)
                .FirstOrDefault(x => x.MesaSelecionada.Numero == numeroMesa);
        }

        public List<Conta> SelecionarPorData(DateTime hoje)
        {

            return ObterRegistros()
                .Where(c => c.EstaFechada())
                .Where(c => c.Data.Equals(hoje.Date))
                .ToList();
        }

        public List<GorjetaDoDia> SelecionarGorjetas(DateTime data)
        {
            var query = from r in ObterRegistros()
                        where r.EstaFechada()
                        select r.Data;


            return SelecionarPorData(data)
                    .GroupBy(c => c.GarcomSelecionado)
                    .Select(x => new GorjetaDoDia(data, x.Key))
                    .ToList();
        }

        public override List<Conta> ObterRegistros()
        {
            return _dataContext.Contas;
        }
    }
}

using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloConta
{
    public class RepositorioContaEmMemoria : RepositorioEmMemoria<Conta>, IRepositorioConta
    {
        //Linq = Language integrated query
        //System.Linq = Extension Methods de Listas
        //Projeções com Select armazenando em variáveis declaradas com "var"
        //Encadeamento de chamadas de métodos linq
        //Dicionários

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
            //System.Linq
            //var 
            var registrosAux01 =
                from r in registros
                where r.EstaFechada()
                where r.Data.Equals(hoje)
                select r.Aberta;

            return registros
                .Where(c => c.EstaFechada())
                .Where(c => c.Data.Equals(hoje.Date))
                .ToList();
        }

        public List<GorjetaDoDia> SelecionarGorjetas(DateTime data)
        {
            return 
                SelecionarPorData(data) //filtro
                .GroupBy(c => c.GarcomSelecionado) //agrupamento
                .Select(x => new GorjetaDoDia(data, x.Key))// projeção
                .ToList(); //conversão
        }
    }
}

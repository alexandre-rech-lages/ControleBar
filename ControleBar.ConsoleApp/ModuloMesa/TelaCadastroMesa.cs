using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.ModuloMesa
{
    internal class TelaCadastroMesa : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Mesa> _repositorioMesa;
        private readonly Notificador _notificador;
        public TelaCadastroMesa(IRepositorio<Mesa> repositorioMesa, Notificador notificador) : base("Cadastro de mesa ")
        {
            _repositorioMesa = repositorioMesa;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Mesa ");

            Mesa mesa = ObterMesa();

            _repositorioMesa.Inserir(mesa);

            _notificador.ApresentarMensagem("Mesa  cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Mesa ");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Mesa cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Mesa mesa = ObterMesa();

            bool conseguiuEditar = _repositorioMesa.Editar(numeroGenero, mesa);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Mesa editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Mesa ");

            bool temMesa = VisualizarRegistros("Pesquisando");

            if (temMesa == false)
            {
                _notificador.ApresentarMensagem("Nenhuma mesa cadastrada para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numMesa = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioMesa.Excluir(numMesa);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Mesa  excluída com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Mesas Cadastradas");

            List<Mesa> mesas = _repositorioMesa.SelecionarTodos();

            if (mesas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum Mesa disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Mesa mesa in mesas)
                Console.WriteLine(mesa.ToString());

            Console.WriteLine();

            return true;
        }

        private Mesa ObterMesa()
        {
            Console.Write("Digite o número da Mesa: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            return new Mesa(numero);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o nº da mesa  que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioMesa.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("Número da mesa não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}

using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class TelaCadastroGarcom : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Garcom> repositorioGarcom;
        private readonly Notificador notificador;

        public TelaCadastroGarcom(IRepositorio<Garcom> repositorioGarcom, Notificador notificador)
            : base("Cadastro de Garçons")
        {
            this.repositorioGarcom = repositorioGarcom;
            this.notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Garçom");

            Garcom novoGarcom = ObterGarcom();

            repositorioGarcom.Inserir(novoGarcom);

            notificador.ApresentarMensagem("Garçom cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Garçom");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum garçom cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Garcom garcomAtualizado = ObterGarcom();

            bool conseguiuEditar = repositorioGarcom.Editar(numeroGenero, garcomAtualizado);

            if (!conseguiuEditar)
                notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                notificador.ApresentarMensagem("Garçom editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Garçom");

            bool temFuncionariosRegistrados = VisualizarRegistros("Pesquisando");

            if (temFuncionariosRegistrados == false)
            {
                notificador.ApresentarMensagem("Nenhum garçom cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroGarcom = ObterNumeroRegistro();

            bool conseguiuExcluir = repositorioGarcom.Excluir(numeroGarcom);

            if (!conseguiuExcluir)
                notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                notificador.ApresentarMensagem("Garçom excluído com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Garçons Cadastrados");

            List<Garcom> garcons = repositorioGarcom.SelecionarTodos();

            if (garcons.Count == 0)
            {
                notificador.ApresentarMensagem("Nenhum garçom disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Garcom garcom in garcons)
                Console.WriteLine(garcom.ToString());

            Console.WriteLine();

            return true;
        }

        private Garcom ObterGarcom()
        {
            Console.Write("Digite o nome do garçom: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o CPF do garçom: ");
            string cpf = Console.ReadLine();

            return new Garcom(nome, cpf);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do garçom que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = repositorioGarcom.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    notificador.ApresentarMensagem("ID do garçom não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
﻿using ControleBar.ConsoleApp.Compartilhado;
using ControleBar.ConsoleApp.ModuloConta;
using System;

namespace ControleBar.ConsoleApp
{
    public class Program
    {
        private static JsonContext jsonContext;

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("exit");
            jsonContext.Gravar();
        }

        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            jsonContext = new JsonContext().Carregar();

            TelaMenuPrincipal telaMenuPrincipal = new TelaMenuPrincipal(new Notificador(), jsonContext);

            while (true)
            {
                TelaBase telaSelecionada = telaMenuPrincipal.ObterTela();

                if (telaSelecionada is null)
                    break;

                string opcaoSelecionada = telaSelecionada.MostrarOpcoes();

                if (telaSelecionada is ITelaCadastravel)
                {
                    ITelaCadastravel telaCadastroBasico = (ITelaCadastravel)telaSelecionada;

                    if (opcaoSelecionada == "1")
                        telaCadastroBasico.Inserir();

                    if (opcaoSelecionada == "2")
                        telaCadastroBasico.Editar();

                    if (opcaoSelecionada == "3")
                        telaCadastroBasico.Excluir();

                    if (opcaoSelecionada == "4")
                    {
                        telaCadastroBasico.VisualizarRegistros("Tela");
                        Console.ReadLine();

                    }
                }

                else if (telaSelecionada is TelaCadastroConta)
                {
                    TelaCadastroConta telaCadastroConta = (TelaCadastroConta)telaSelecionada;

                    if (opcaoSelecionada == "1")
                        telaCadastroConta.AbrirNovaConta();

                    else if (opcaoSelecionada == "2")
                        telaCadastroConta.AdicionarPedido();

                    else if (opcaoSelecionada == "3")
                        telaCadastroConta.FecharConta();

                    else if (opcaoSelecionada == "4")
                    {
                        telaCadastroConta.VisualizarContasAbertas();
                        Console.ReadLine();
                    }
                    else if (opcaoSelecionada == "5")
                    {
                        telaCadastroConta.VisualizarFaturamento();
                        Console.ReadLine();
                    }
                }

            }
        }
    }
}

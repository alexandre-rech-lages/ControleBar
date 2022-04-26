using System;

namespace ControleBar.ConsoleApp.Compartilhado
{
    public abstract class TelaBase
    {
        protected string Titulo { get; set; }

        public TelaBase(string titulo)
        {
            Titulo = titulo;
        }


        public virtual string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        /// <summary>
        /// Tipos aceitos: int, decimal e DateTime
        /// </summary>
        /// <param name="mensagem">Mensagem que será aprensentada na tela</param>        
        /// <returns>Valor convertido para o tipo informado</returns>
        protected static T ObterValor<T>(string mensagem)
        {
            mensagem = mensagem.Trim();
            mensagem = mensagem.Replace(":", "");
            mensagem = mensagem + ": ";

            T valor;
            string sValor;

            while (true)
            {
                try
                {
                    Console.Write(mensagem);
                    sValor = Console.ReadLine();
                    valor = (T)Convert.ChangeType(sValor, typeof(T));
                    break;
                }
                catch
                {
                    string name = typeof(T).Name.ToUpper();
                    string msgErro;

                    switch (name)
                    {
                        case "DATETIME": msgErro = "Digite uma data no formato dd/mm/aaaa"; break;
                        case "INT32": msgErro = "Digite um número"; break;
                        case "DECIMAL": msgErro = "Digite um número no formato 2,5"; break;

                        default:
                            msgErro = "Formato do campo inválido, tente novamente"; break;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msgErro);
                    Console.ResetColor();
                }
            }

            return valor;
        }
    }
}

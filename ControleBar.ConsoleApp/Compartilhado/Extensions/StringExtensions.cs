using System.Collections.Generic;

namespace ControleBar.ConsoleApp.Compartilhado
{
    public static class StringExtensions
    {
        public static string SelecionarVogais(this string nome)
        {
            char[] array = nome.ToLower().ToCharArray();

            List<char> vogais = new List<char>();

            foreach (var item in array)
            {
                if (item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u')
                    vogais.Add(item);
            }

            return string.Join("", vogais);
        }

        public static int ObtemQuantidadeVogais(this string nome)
        {
            char[] array = nome.ToLower().ToCharArray();

            int qtd = 0;

            foreach (var item in array)
            {
                if (item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u')
                    qtd++;
            }

            return qtd;
        }
    }
}

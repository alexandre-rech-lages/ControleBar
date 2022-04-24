using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.Compartilhado
{
    public static class ListExtensions
    {
        public static void MostrarElementos<T>(this List<T> elementos) 
        {
            foreach (var item in elementos)
            {
                Console.WriteLine(item);
            }
        }
    }
}

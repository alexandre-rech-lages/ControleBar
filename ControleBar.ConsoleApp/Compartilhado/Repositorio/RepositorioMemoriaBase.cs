using System;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.Compartilhado
{
    //RepositorioBase
    public abstract class RepositorioEmMemoria<T> : IRepositorio<T> where T : EntidadeBase<T>
    {
        protected readonly List<T> registros;

        protected int contadorId;

        public RepositorioEmMemoria()
        {
            registros = new List<T>();
        }

        public virtual string Inserir(T entidade)
        {
            entidade.Numero = ++contadorId;

            registros.Add(entidade);

            return "REGISTRO_VALIDO";
        }

        public bool Editar(int idSelecionado, T novaEntidade)
        {
            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.Numero)
                {
                    novaEntidade.Numero = entidade.Numero;

                    entidade.Atualizar(novaEntidade);

                    return true;
                }
            }

            return false;
        }

        public bool Editar(Predicate<T> condicao, T novaEntidade)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                {
                    novaEntidade.Numero = entidade.Numero;

                    entidade.Atualizar(novaEntidade);

                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int idSelecionado)
        {
            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.Numero)
                {
                    registros.Remove(entidade);
                    return true;
                }
            }
            return false;
        }

        public bool Excluir(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                {
                    registros.Remove(entidade);
                    return true;
                }
            }
            return false;
        }

        public T SelecionarRegistro(int idSelecionado)
        {
            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.Numero)
                    return entidade;
            }

            return null;
        }

        public T SelecionarRegistro(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                    return entidade;
            }

            return null;
        }

        public List<T> SelecionarTodos()
        {
            return registros;
        }

        public List<T> Filtrar(Predicate<T> condicao)
        {
            List<T> registrosFiltrados = new List<T>();

            foreach (T entidade in registros)
                if (condicao(entidade))
                    registrosFiltrados.Add(entidade);

            return registrosFiltrados;
        }

        public bool ExisteRegistro(int idSelecionado)
        {
            foreach (T entidade in registros)
                if (idSelecionado == entidade.Numero)
                    return true;

            return false;
        }

        public bool ExisteRegistro(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
                if (condicao(entidade))
                    return true;

            return false;
        }
    }
}

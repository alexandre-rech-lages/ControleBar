using System;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.Compartilhado
{
    public abstract class RepositorioEmArquivo<T> : IRepositorio<T> where T : EntidadeBase<T>
    {
        protected DataContext _dataContext;

        protected int contadorId;

        public RepositorioEmArquivo(DataContext dataContext)
        {
            _dataContext = dataContext;
            AtualizarContador();
        }

        public abstract List<T> ObterRegistros();

        public abstract void AtualizarContador();

        public virtual string Inserir(T entidade)
        {
            var registros = ObterRegistros();

            entidade.Numero = ++contadorId;

            registros.Add(entidade);

            return "REGISTRO_VALIDO";
        }

        public bool Editar(int idSelecionado, T novaEntidade)
        {
            var registros = ObterRegistros();

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
            var registros = ObterRegistros();

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
            var registros = ObterRegistros();

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
            var registros = ObterRegistros();

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
            var registros = ObterRegistros();

            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.Numero)
                    return entidade;
            }

            return null;
        }

        public T SelecionarRegistro(Predicate<T> condicao)
        {
            var registros = ObterRegistros();

            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                    return entidade;
            }

            return null;
        }

        public List<T> SelecionarTodos()
        {
            return ObterRegistros();
        }

        public List<T> Filtrar(Predicate<T> condicao)
        {
            List<T> registrosFiltrados = new List<T>();

            var registros = ObterRegistros();

            foreach (T entidade in registros)
                if (condicao(entidade))
                    registrosFiltrados.Add(entidade);

            return registrosFiltrados;
        }

        public bool ExisteRegistro(int idSelecionado)
        {
            var registros = ObterRegistros();

            foreach (T entidade in registros)
                if (idSelecionado == entidade.Numero)
                    return true;

            return false;
        }

        public bool ExisteRegistro(Predicate<T> condicao)
        {
            var registros = ObterRegistros();

            foreach (T entidade in registros)
                if (condicao(entidade))
                    return true;

            return false;
        }
    }
}

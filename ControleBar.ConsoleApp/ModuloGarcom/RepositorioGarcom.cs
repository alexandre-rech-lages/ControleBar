﻿using ControleBar.ConsoleApp.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class RepositorioGarcomEmMemoria : RepositorioEmMemoria<Garcom>
    {
    }

    public class RepositorioGarcomEmArquivo : RepositorioEmArquivo<Garcom>
    {
        public RepositorioGarcomEmArquivo(DataContext dataContext) : base(dataContext)
        {            
        }

        public override void AtualizarContador()
        {
            if (_dataContext.Garcons.Count > 0)
                contadorId = _dataContext.Garcons.Max(x => x.Numero);
        }

        public override List<Garcom> Registros()
        {
            return _dataContext.Garcons;
        }
    }


}
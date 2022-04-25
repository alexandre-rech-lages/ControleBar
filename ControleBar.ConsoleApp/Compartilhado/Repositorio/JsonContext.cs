using ControleBar.ConsoleApp.ModuloConta;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloProduto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ControleBar.ConsoleApp.Compartilhado
{
    public class JsonContext
    {
        private List<Garcom> garcons;
        private List<Produto> produtos;
        private List<Mesa> mesas;
        private List<Conta> contas;

        public List<Garcom> Garcons
        {
            get
            {
                if (garcons == null)
                    return garcons = new List<Garcom>();

                return garcons;
            }
        }

        public List<Produto> Produtos
        {
            get
            {
                if (produtos == null)
                    return produtos = new List<Produto>();

                return produtos;
            }
        }
        public List<Mesa> Mesas
        {
            get
            {
                if (mesas == null)
                    return mesas = new List<Mesa>();

                return mesas;
            }
        }

        public List<Conta> Contas
        {
            get
            {
                if (contas == null)
                    return contas = new List<Conta>();

                return contas;
            }
        }

        public void Gravar()
        {
            var settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented,
            };

            var arquivo = JsonConvert.SerializeObject(this, settings);

            File.WriteAllText(Environment.CurrentDirectory + "\\arquivo.json", arquivo);
        }

        public JsonContext Carregar()
        {
            var settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented,
            };

            if (File.Exists(Environment.CurrentDirectory + "\\arquivo.json"))
            {
                var arquivo = File.ReadAllText(Environment.CurrentDirectory + "\\arquivo.json");

                return JsonConvert.DeserializeObject<JsonContext>(arquivo, settings);
            }

            return new JsonContext();
        }

    }
}

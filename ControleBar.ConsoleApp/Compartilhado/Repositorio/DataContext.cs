using ControleBar.ConsoleApp.ModuloConta;
using ControleBar.ConsoleApp.ModuloGarcom;
using ControleBar.ConsoleApp.ModuloMesa;
using ControleBar.ConsoleApp.ModuloProduto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ControleBar.ConsoleApp.Compartilhado
{
    [Serializable]
    public class DataContext //classe container
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

        public DataContext()
        {
            CarregarBinario();
        }
        
        public void GravarEmJson()
        {
            var settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented,
            };

            var arquivo = JsonConvert.SerializeObject(this, settings);

            File.WriteAllText(Environment.CurrentDirectory + "\\arquivo.json", arquivo);
        }

        public void GravarEmXml()
        {
            var arquivo = Environment.CurrentDirectory + "\\arquivo.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataContext));

            using (FileStream fs = new FileStream(arquivo, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, this);
            }
        }

        public void GravarBinario()
        {
            var arquivo = Environment.CurrentDirectory + "\\arquivo.bin";

            using (FileStream fs = new FileStream(arquivo, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(fs, this);
            }
        }

        #region métodos privados
        private void CarregarBinario()
        {
            var arquivo = Environment.CurrentDirectory + "\\arquivo.bin";

            if (File.Exists(arquivo))
            {
                using (FileStream fs = new FileStream(arquivo, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    if (fs.Length > 0)
                    {
                        var ctx = (DataContext)formatter.Deserialize(fs);

                        CarregarDoContexto(ctx);
                    }
                }
            }
        }

        private void CarregarJson()
        {
            var settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                Formatting = Formatting.Indented,
            };

            if (File.Exists(Environment.CurrentDirectory + "\\arquivo.json"))
            {
                var arquivo = File.ReadAllText(Environment.CurrentDirectory + "\\arquivo.json");

                var ctx = JsonConvert.DeserializeObject<DataContext>(arquivo, settings);

                CarregarDoContexto(ctx);
            }
        }
        
        private DataContext CarregarXml()
        {
            var arquivo = Environment.CurrentDirectory + "\\arquivo.xml";

            if (File.Exists(arquivo))
            {
                using (FileStream fs = new FileStream(arquivo, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataContext));

                    if (fs.Length > 0) {                         
                        var ctx = (DataContext)xmlSerializer.Deserialize(fs);

                        CarregarDoContexto(ctx);
                    }
                }
            }

            return new DataContext();
        }

        private void CarregarDoContexto(DataContext ctx)
        {
            garcons = ctx.Garcons;
            produtos = ctx.Produtos;
            mesas = ctx.Mesas;
            contas = ctx.Contas;
        }

        #endregion  
    }
}

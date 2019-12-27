using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Target_WebAPI.Models
{
    public class TargetAgenda
    {
        public long ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public TipoAgendamento tipoAgendamento { get; set; }
        public string Observacao { get; set; }

        public List<TargetAgenda> listarAgenda()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data\Agendas.json");
            var json = File.ReadAllText(filePath);
            var listaAgenda = JsonConvert.DeserializeObject<List<TargetAgenda>>(json);
            return listaAgenda;
        }

        public bool RescreveArquivo(List<TargetAgenda> listaAgenda)
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data\Agendas.json");
            var json = JsonConvert.SerializeObject(listaAgenda, Formatting.Indented);
            File.WriteAllText(filePath, json);
            return true;
        }

        public TargetAgenda Inserir(TargetAgenda agenda)
        {
            var listaAgendas = this.listarAgenda();
            var maxID = listaAgendas.Max(p => p.ID);
            agenda.ID = maxID + 1;
            listaAgendas.Add(agenda);
            RescreveArquivo(listaAgendas);
            return agenda;
        }

        public TargetAgenda Atualizar(int id, TargetAgenda agenda)
        {
            var listaAgendas = this.listarAgenda();
            var itemIndex = listaAgendas.FindIndex(p => p.ID == id);
            if (itemIndex >= 0)
            {
                agenda.ID = id;
                listaAgendas[itemIndex] = agenda;
            }
            else
            {
                return null;
            }

            RescreveArquivo(listaAgendas);
            return agenda;
        }

        public bool Deletar(int id)
        {
            var listaAgendas = this.listarAgenda();
            var itemIndex = listaAgendas.FindIndex(p => p.ID == id);
            if(itemIndex >= 0)
            {
                listaAgendas.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            RescreveArquivo(listaAgendas);
            return true;
        }
    }

    public enum TipoAgendamento
    {
        Novo,
        Retorno
    }


}
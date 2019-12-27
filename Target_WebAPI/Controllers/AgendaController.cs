using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Target_WebAPI.Models;

namespace Target_WebAPI.Controllers
{
    public class AgendaController : ApiController
    {
        // GET: api/Agenda
        public IEnumerable<TargetAgenda> Get()
        {
            TargetAgenda agenda = new TargetAgenda();
            return agenda.listarAgenda();
        }

        // GET: api/Agenda/5
        public TargetAgenda Get(int id)
        {
            TargetAgenda agenda = new TargetAgenda();

            return agenda.listarAgenda().Where(x => x.ID == id).FirstOrDefault();
        }

        // POST: api/Agenda
        public List<TargetAgenda> Post(TargetAgenda agenda)
        {
            TargetAgenda _agenda = new TargetAgenda();
            _agenda.Inserir(agenda);
            return _agenda.listarAgenda();
        }

        // PUT: api/Agenda/5
        public TargetAgenda Put(int id, [FromBody]TargetAgenda agenda)
        {
            TargetAgenda _agenda = new TargetAgenda();
            return _agenda.Atualizar(id, agenda);
        }

        // DELETE: api/Agenda/5
        public void Delete(int id)
        {
            TargetAgenda _agenda = new TargetAgenda();
            _agenda.Deletar(id);
        }
    }
}

using APIAgendaMongo.Models;
using APIAgendaMongo.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;

namespace APIAgendaMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientServices _clientService;
        private readonly AdressServices _adressService;

        public ClientController(ClientServices clientService, AdressServices adressService)
        {
            _clientService = clientService;
            _adressService = adressService;
        }

        [HttpGet]
        public ActionResult<List<Client>> Get() => _clientService.Get();

        [HttpGet("Client/{Id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.Get(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpGet("ClientAdress/{endereco:length(24)}", Name = "GetClientAdress")]
        public ActionResult<Client> GetClient(string endereco)
        {
            var client = _clientService.Get().FirstOrDefault(x => x.Adress.Id == endereco);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpGet("ClientName/{name:maxlength(30)}", Name = "GetClientName")]
        public ActionResult<Client> GetClientName(string name)
        {
            var client = _clientService.Get().FirstOrDefault(x => x.Name == name);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public ActionResult<Client> Post(Client client)
        {
            Adress adress = _adressService.Create(client.Adress);
            client.Adress = adress;
            _clientService.Create(client);
            return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
        }

        [HttpPut]
        public ActionResult<Client> Put(Client clientIn, string id)
        {
            var client = _clientService.Get(id);
            if (client == null) return NotFound("Não encontrado");
            _clientService.Update(client.Id, clientIn);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Client> Delete(string id)
        {
            Client client = _clientService.Get(id);
            if (client == null) return NotFound();
            _clientService.Remove(client);
            return NoContent();
        }
    }
}

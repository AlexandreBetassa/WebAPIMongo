using APIAgendaMongo.Models;
using APIAgendaMongo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIAgendaMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly AdressServices _adressService;

        public AdressController(AdressServices adressServices) => _adressService = adressServices;

        [HttpGet]
        public ActionResult<List<Adress>> Get() => _adressService.Get();

        [HttpGet("{Id:length(24)}", Name = "GetAdress")]
        public ActionResult<Adress> Get(string id)
        {
            var adress = _adressService.Get(id);
            if (adress == null) return NotFound();
            return Ok(adress);
        }

        [HttpPost]
        public ActionResult<Adress> Post(Adress adress)
        {
            _adressService.Create(adress);
            return CreatedAtRoute("GetAdress", new { id = adress.Id.ToString() }, adress);
        }

        [HttpPut]
        public ActionResult<Adress> Put(Adress adressIn, string id)
        {
            var adress = _adressService.Get(id);
            if (adress == null) return NotFound("Não encontrado");
            _adressService.Update(adress.Id, adressIn);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Adress> Delete(string id)
        {
            Adress adress = _adressService.Get(id);
            if (adress == null) return NotFound();
            _adressService.Remove(adress);
            return NoContent();
        }
    }
}

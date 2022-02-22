using ApiFundacion.Models;
using ApiFundacion.Repository.Publicaciones;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFundacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Prog3")]
    public class PublicacionesController : ControllerBase
    {

        private readonly IPublicacionesRepository publicacionesRepository;

        public PublicacionesController(IPublicacionesRepository publicacionesRepository)
        {
            this.publicacionesRepository = publicacionesRepository;
        }
        // GET: api/<PublicacionesController>
        [HttpGet]
        public async Task<List<Publicacionesxproyecto>> Get()
        {
            return await publicacionesRepository.GetPublicaciones();
        }

        // GET api/<PublicacionesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PublicacionesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PublicacionesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublicacionesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

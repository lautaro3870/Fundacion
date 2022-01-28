using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using ApiFundacion.Repository.Usuarios;
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
    public class PersonalController : ControllerBase
    {

        IUsuarioRepository _usuarioRepository;

        public dena66utud3alcContext context;

        public PersonalController(IUsuarioRepository usuarioRepository, dena66utud3alcContext context)
        {
            _usuarioRepository = usuarioRepository;
            this.context = context;

        }


        // GET: api/<PersonalController>
        [HttpGet]
        public List<Personal> Get()
        {
            return _usuarioRepository.GetUsuario();
        }

        // GET api/<PersonalController>/5
        //[HttpGet("Login")]
        //public Usuario Login([FromBody] Usuario personal)
        //{
        //    return _usuarioRepository.Login(personal);
        //}



        [HttpPost("Login")]
        public Personal Login([FromBody] Personal personal)
        {

            Personal p = new Personal()
            {
                Email = personal.Email,
                Password = personal.Password
            };
            return _usuarioRepository.Login(p);
        }

        // POST api/<PersonalController>
        [HttpPost]
        public Personal Singup([FromBody] PersonalDTO personal)
        {
            //var email = personal.Email;
            //var contra = personal.Password;

            //try
            //{
            //    var usuario = context.Personals.FirstOrDefault(x => x.Email == email && x.Password == contra);
            //    return usuario;
            //} catch (Exception ex)
            //{
            //    return null;
            //}

            Personal p = new Personal()
            {
                Email = personal.Email,
                Password = personal.Password
            };

            return _usuarioRepository.Signup(p);
        }


    }
}

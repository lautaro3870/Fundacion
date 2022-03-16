using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using ApiFundacion.Repository.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFundacion.Controllers
{
    //[Authorize]
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
            return _usuarioRepository.GetPersonal();
        }

        [HttpGet("Usuarios")]
        public async Task<List<Usuario>> GetUsuariosLogin()
        {
            return await _usuarioRepository.GetUsuarioLogin();
        }


        // GET api/<PersonalController>/5
        //[HttpGet("Login")]
        //public Usuario Login([FromBody] Usuario personal)
        //{
        //    return _usuarioRepository.Login(personal);
        //}

        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate([FromBody] UsuarioDTO usuario)
        //{

        //    UsuarioDTO u = new UsuarioDTO
        //    {
        //        Email = usuario.Email,
        //        Password = usuario.Password
        //    };

        //    var token = _usuarioRepository.Authenticate(u);
        //    return token != null ? Ok(token) : Unauthorized();
        //}


        [HttpPost("Login")]
        public ResultadosApi Login([FromBody] Usuario usuario)
        {
            Usuario u = new Usuario
            {
                Email = usuario.Email,
                Password = usuario.Password              
            };

            return _usuarioRepository.Login(u);
        }

        [HttpPut("Update")]
        public bool Update(UsuarioUpdate usuario)
        {
            return _usuarioRepository.UpdatePass(usuario);
        }

        // POST api/<PersonalController>
        [HttpPost]
        public Usuario Singup([FromBody] Usuario usuario)
        {
            return _usuarioRepository.Signup(usuario);
        }


    }
}

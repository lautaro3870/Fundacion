﻿using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using ApiFundacion.Repository.Usuarios;
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
        //[HttpGet]
        //public List<Personal> Get()
        //{
        //    return _usuarioRepository.GetPersonal();
        //}

        // GET api/<PersonalController>/5
        [HttpGet]
        public Personal Login([FromBody] Personal personal)
        {
            return _usuarioRepository.Login(personal);
        }

        // POST api/<PersonalController>
        [HttpPost]
        public Personal Singup([FromBody] Personal personal)
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
            return _usuarioRepository.Signup(personal);
        }


    }
}

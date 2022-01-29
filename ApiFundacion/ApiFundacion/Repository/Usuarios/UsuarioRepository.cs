using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ApiFundacion.Resultados.Resultados;



namespace ApiFundacion.Repository.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly dena66utud3alcContext context;

        public UsuarioRepository(dena66utud3alcContext context)
        {
            this.context = context;
        }

        //public List<Usuario> GetUsuario()
        //{
        //    return context.Usuarios.ToList();
        //}

        //public Usuario Login(Usuario oPersonal)
        //{
        //    var personal = context.Usuarios.SingleOrDefault(x => x.Email == oPersonal.Email);
        //    bool isValidPassword = BCrypt.Net.BCrypt.Verify(oPersonal.Password, personal.Password);

        //    if(isValidPassword)
        //    {
        //        return personal;
        //    }
        //    return null;
        //}

        public async Task<Personal> Login(Personal oPersonal)
        {

                var personal = await context.Personals.SingleOrDefaultAsync(x => x.Email == oPersonal.Email);
            //el metodo verify de la clase Bcrypt es estatico, por ende no se debe instanciar la clase, solo se implementa
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(oPersonal.Password, personal.Password);

                if (!isValidPassword)
                {
                    throw new Exception("Error logueo");
                }

                return personal;
            
        }


        //public Usuario Signup(Usuario oPersonal)
        //{
        //    oPersonal.Password = BCrypt.Net.BCrypt.HashPassword(oPersonal.Password);
        //    context.Usuarios.Add(oPersonal);
        //    context.SaveChanges();
        //    return oPersonal;
        //}

        public Personal Signup(Personal oPersonal)
        {
            oPersonal.Password = BCrypt.Net.BCrypt.HashPassword(oPersonal.Password);
            context.Personals.Add(oPersonal);
            context.SaveChanges();
            return oPersonal;
        }

        public List<Personal> GetUsuario()
        {
            return context.Personals.ToList();
        }
    }
}

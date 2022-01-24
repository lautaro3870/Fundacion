using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ApiFundacion.Repository.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly dena66utud3alcContext context;

        public UsuarioRepository(dena66utud3alcContext context)
        {
            this.context = context;
        }

        public List<Personal> GetPersonal()
        {
            return context.Personals.ToList();
        }

        

        public Personal Login(Personal oPersonal)
        {
            var personal = context.Personals.SingleOrDefault(x => x.Email == oPersonal.Email);
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(oPersonal.Password, personal.Password);

            if(isValidPassword)
            {
                return personal;
            }
            return null;
        }

        public Personal Signup(Personal oPersonal)
        {
            oPersonal.Password = BCrypt.Net.BCrypt.HashPassword(oPersonal.Password);
            context.Personals.Add(oPersonal);
            return oPersonal;
        }
    }
}

using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ApiFundacion.Resultados.Resultados;



namespace ApiFundacion.Repository.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly dena66utud3alcContext context;
        private readonly string key;

        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {
                "test1", "password1"
            }
        };

        public UsuarioRepository(dena66utud3alcContext context)
        {
            this.context = context;
        }

        public UsuarioRepository(string key)
        {
            this.key = key;
        }

        //public string Authenticate(UsuarioDTO usuario)
        //{
        //    if (!context.Usuarios.Any(u => u.Email == null && u.Password == null))
        //    {
        //        return null;
        //    }
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var tokenKey = Encoding.ASCII.GetBytes(key);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[] {
        //            new Claim(ClaimTypes.Email, usuario.Email)
        //        }),
        //        Expires = DateTime.UtcNow.AddHours(1),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
        //            SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        public List<Personal> GetPersonal()
        {
            return  context.Personals.Where(x => x.Nombre != null).OrderBy(x => x.Id).ToList();
        }

        public List<Usuario> GetUsuario()
        {
            return context.Usuarios.ToList();
        }

        public async Task<List<Usuario>> GetUsuarioLogin()
        {
            return await context.Usuarios.Where(x => x.Activo == true).ToListAsync();
        }

        public Usuario Login(Usuario oPersonal)
        {
            var personal = context.Usuarios.SingleOrDefault(x => x.Email == oPersonal.Email);
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(oPersonal.Password, personal.Password);

            if (isValidPassword)
            {
                return personal;
            }
            return null;
        }

        //public async Task<Personal> Login(Personal oPersonal)
        //{

        //    var personal = await context.Personals.SingleOrDefaultAsync(x => x.Email == oPersonal.Email);
        //    el metodo verify de la clase Bcrypt es estatico, por ende no se debe instanciar la clase, solo se implementa
        //        bool isValidPassword = BCrypt.Net.BCrypt.Verify(oPersonal.Password, personal.Password);

        //    if (!isValidPassword)
        //    {
        //        throw new Exception("Error logueo");
        //        return null;
        //    }

        //    return personal;

        //}


        public Usuario Signup(Usuario oPersonal)
        {
            oPersonal.Password = BCrypt.Net.BCrypt.HashPassword(oPersonal.Password);
            context.Usuarios.Add(oPersonal);
            context.SaveChanges();
            return oPersonal;
        }

        public bool UpdatePass(UsuarioUpdate usuario)
        {
            var usu = context.Usuarios.SingleOrDefault(x => x.Email == usuario.Email);
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(usuario.PasswordVieja, usu.Password);

            if (isValidPassword)
            {
                usu.Password = BCrypt.Net.BCrypt.HashPassword(usuario.PasswordNueva);
                context.Usuarios.Update(usu);
                context.SaveChanges();
                return true;
            }
            return false;

        }

        //public Personal Signup(Personal oPersonal)
        //{
        //    oPersonal.Password = BCrypt.Net.BCrypt.HashPassword(oPersonal.Password);
        //    context.Personals.Add(oPersonal);
        //    context.SaveChanges();
        //    return oPersonal;
        //}

        //public List<Personal> GetUsuario()
        //{
        //    return context.Personals.ToList();
        //}
    }
}

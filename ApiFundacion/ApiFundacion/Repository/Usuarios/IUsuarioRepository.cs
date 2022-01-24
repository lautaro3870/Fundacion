using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Repository.Usuarios
{
    public interface IUsuarioRepository
    {
        Personal Signup(Personal oPersonal);
        Personal Login(Personal oPersonal);
        List<Personal> GetPersonal();
    }
}

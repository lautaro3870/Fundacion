using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Repository.Usuarios
{
    public interface IUsuarioRepository
    {
        Usuario Signup(Usuario oPersonal);
        ResultadosApi Login(Usuario oPersonal);
        List<Usuario> GetUsuario();
        bool UpdatePass(UsuarioUpdate usuario);
        List<Personal> GetPersonal();

        //Task<Personal> Login(Personal oPersonal);
        Task<List<Usuario>> GetUsuarioLogin();

        //string Authenticate(UsuarioDTO usuario);

    }
}

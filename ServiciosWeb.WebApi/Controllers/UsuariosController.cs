using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiciosWeb.Datos.Modelo;
using System.Web.Http.Cors;

namespace ServiciosWeb.WebApi.Controllers
{
    [RoutePrefix("api/usuarios")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
    {
        videoBlockEntities BD = new videoBlockEntities();
        [HttpGet]
        [AllowAnonymous]
        [Route("retornarUsuarios")]
        /// <summary>
        /// Método que trae todos los usuarios de la aplicacion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> Get()
        {
            var listado = BD.Usuarios.ToList();
            return listado;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("retornarUsuariosRegistrados")]
        /// <summary>
        /// Método que verifica si un usuario se encuentra registrado en la base de datos para permitir el ingreso
        /// </summary>
        /// <param name="Usuarios"></param>
        /// <returns></returns>
        public IEnumerable<Usuario> Post(Usuario Usuarios)
        {
            var listado = BD.Usuarios.ToList().Where(u => u.Contraseña == Usuarios.Contraseña && u.UsuarioRegistrado == Usuarios.UsuarioRegistrado);
            return listado;
        }
    }
}

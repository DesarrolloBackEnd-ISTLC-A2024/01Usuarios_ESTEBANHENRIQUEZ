using _01Usuarios_ESTEBANHENRIQUEZ.Comunes;
using _01Usuarios_ESTEBANHENRIQUEZ.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _01Usuarios_ESTEBANHENRIQUEZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioController>
        [HttpGet]
        public List<Usuarios> Get()
        {
            return ConexionBD.GetUsuarios();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public Usuarios Get(int id)
        {
            return ConexionBD.GetUsuarios(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] Usuarios objUsuario)
        {
            ConexionBD.PostUsuarios(objUsuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{usuarioModificacion}")]
        public void Put(int usuarioModificacion, [FromBody] Usuarios objUsuario)
        {
            ConexionBD.PutUsuario(usuarioModificacion, objUsuario);
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{idUsuario}/{idUsuarioModificacion}")]
        public void Delete(int idUsuario, int idUsuarioModificacion)
        {
            ConexionBD.DeleteUsuario(idUsuario, idUsuarioModificacion);
        }
    }
}

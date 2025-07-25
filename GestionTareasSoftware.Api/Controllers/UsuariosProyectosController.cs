using Dapper;
using GestionTareasSoftware.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionTareasSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosProyectosController : ControllerBase
    {
        public DbConnection connection;
        public UsuariosProyectosController(IConfiguration config)
        {
            var connString = config.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connString);
            connection.Open();

        }
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var UsuariosProyectos = connection.Query<dynamic>("SELECT * FROM UsuarioProyectos").ToList();
            return UsuariosProyectos;
        }
        // GET api/<UsuariosProyectosController>/5
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var Usuarios = connection.QuerySingle<dynamic>("SELECT * FROM UsuarioProyectos WHERE id=@id", new { id = id });
            return Usuarios;
        }

        // POST api/<UsuariosProyectosController>
        [HttpPost]
        public dynamic Post([FromBody] UsuarioProyecto uproyecto)
        {
            connection.Execute(
                @"INSERT INTO UsuarioProyectos (Id,idProyecto,idUsuario) 
                VALUES (@Id,@idProyecto, @idUsuario)
                ", new
                {
                    Id = uproyecto.Id,
                    idProyecto = uproyecto.idProyecto,
                    idUsuario = uproyecto.idUsuario
                });
            return uproyecto;
        }

        // PUT api/<UsuariosProyectosController>/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] UsuarioProyecto Usuario)
        {
            connection.Execute("Update UsuarioProyectos  Set idProyecto= @idProyecto,idUsuario=@idUsuario Where Id=@Id", Usuario);
            return Usuario;
        }

        // DELETE api/<UsuariosProyectosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute("Delete From UsuarioProyectos Where Id=@Id", new { id = id });
        }
    }
}

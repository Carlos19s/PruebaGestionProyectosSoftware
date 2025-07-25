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
    public class UsuariosController : ControllerBase
    {
        public DbConnection connection;
        public UsuariosController(IConfiguration config)
        {
            var connString = config.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connString);
            connection.Open();

        }
        [HttpGet("Proyectos/{id}")]
        public IEnumerable<dynamic> GetTareasByProyecto(int id)
        {
            var data = connection.Query<dynamic>("SELECT* FROM Proyectos").Aggregate(new List<dynamic>(), (list, proyectos) =>
            {
                if (proyectos.id == id)
                {
                    list.Add(proyectos);
                }
                return list;
            });
            return data;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var Usuarios = connection.Query<dynamic>("SELECT * FROM Usuarios").ToList();
            return Usuarios;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var Usuarios = connection.QuerySingle<dynamic>("SELECT * FROM Usuarios WHERE Id=@Id", new { Id = id });
            return Usuarios;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public dynamic Post([FromBody] Usuario usuario)
        {
            connection.Execute(
                @"INSERT INTO Usuarios (Id,Nombre,Email, Password) 
                VALUES (@Id,@Nombre, @Email, @Password)
                ", new
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    Password = usuario.Password
                });
            return usuario;
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Usuario Usuario)
        {
            connection.Execute("Update Usuarios  Set Nombre= @Nombre,Email=@Email,Password=@Password Where Id=@Id", Usuario);
            return Usuario;
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute("Delete From Usuarios Where Id=@Id", new { Id = id });
        }
    }
}

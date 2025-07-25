using Dapper;
using GestionTareasSoftware.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionTareasSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        public DbConnection connection;
        public ProyectosController(IConfiguration config)
        {
            var connString = config.GetConnectionString("DefaultConnection");
            connection = new MySqlConnector.MySqlConnection(connString);
            connection.Open();

        }
        // GET: api/<ProyectosController>
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var Tareas = connection.Query<dynamic>("SELECT * FROM Proyectos").ToList();
            return Tareas;
        }

        // GET api/<ProyectosController>/5
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var Proyectos = connection.QuerySingle<dynamic>("SELECT * FROM Proyectos WHERE id=@id", new { id = id });
            return Proyectos;
        }

        // POST api/<ProyectosController>
        [HttpPost]
        public dynamic Post([FromBody] Proyecto proyecto)
        {
            connection.Execute(
                @"INSERT INTO Usuarios (Id,Nombre,Email, Password) 
                VALUES (@Id,@Nombre, @Email, @Password)
                ", new
                {
                  
                });
            return "";
        }

        // PUT api/<ProyectosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProyectosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

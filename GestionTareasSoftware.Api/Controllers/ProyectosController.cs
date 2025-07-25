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
    public class ProyectosController : ControllerBase
    {
        public DbConnection connection;
        public ProyectosController(IConfiguration config)
        {
            var connString = config.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connString);
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
            var Proyectos = connection.QuerySingle<dynamic>("SELECT * FROM Proyectos WHERE Id=@Id", new { id = id });
            return Proyectos;
        }

        // POST api/<ProyectosController>
        [HttpPost]
        public dynamic Post([FromBody] Proyecto proyecto)
        {
            connection.Execute(
                @"INSERT INTO Proyectos (Id,NombreProyecto,Descripcion) 
                VALUES (@Id,@NombreProyecto, @Descripcion)
                ", new
                {
                  Id=proyecto.Id,
                  NombreProyecto = proyecto.NombreProyecto,
                  Descripcion = proyecto.Descripcion
                });
            return proyecto;
        }

        // PUT api/<ProyectosController>/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Proyecto proyecto)
        {
            connection.Execute("Update Proyectos  Set NombreProyecto= @NombreProyecto,Descripcion=@Descripcion  Where Id=@Id", proyecto);
            return proyecto;
        }

        // DELETE api/<ProyectosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute("Delete From Proyectos Where Id=@Id", new { id = id });
        }
    }
}

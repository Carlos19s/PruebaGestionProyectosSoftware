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
    public class TareasController : ControllerBase
    {
        public DbConnection connection;
        public TareasController(IConfiguration config)
        {
            var connString = config.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connString);
            connection.Open();

        }
        // GET: api/<TareasController>
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var Tareas = connection.Query<dynamic>("SELECT * FROM Tareas").ToList();
            return Tareas;
        }
        [HttpGet("Proyecto/{id}")]
            public IEnumerable<dynamic> GetTareasByProyecto(int id)
            {
                var data = connection.Query<dynamic>("SELECT * FROM Tareas").Aggregate(new List<dynamic>(), (list, tarea) =>
                {
                    if (tarea.idProyecto == id)
                    {
                        list.Add(tarea);
                    }
                    return list;
                });
                return data;
        }

        // GET api/<TareasController>/5
        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            var Tareas = connection.QuerySingle<dynamic>("SELECT * FROM Tareas WHERE Id=@Id", new { Id = id });
            return Tareas;
        }

        // POST api/<TareasController>
        [HttpPost]
        public dynamic Post([FromBody] Tarea tarea)
        {
            connection.Execute(
                @"INSERT INTO Tareas (Id,Nombretarea,Descripcion,Estado,idProyecto) 
                VALUES (@Id,@Nombretarea, @Descripcion, @Estado,@idProyecto)
                ", new
                {
                    Id = tarea.Id,
                    Nombretarea = tarea.Nombretarea,
                    Descripcion = tarea.Descripcion,
                    Estado = tarea.Estado,
                    idProyecto= tarea.idProyecto

                });
            return tarea;
        }

        // PUT api/<TareasController>/5
        [HttpPut("{id}")]
        public dynamic Put(int id, [FromBody] Tarea tarea)
        {
            connection.Execute("Update Tareas  Set Nombretarea= @Nombretarea,Descripcion=@Descripcion,Estado=@Estado Where Id=@Id", tarea);
            return tarea;
        }

        // DELETE api/<TareasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            connection.Execute("Delete From Tareas Where Id=@Id", new { Id = id });
        }
    }
}

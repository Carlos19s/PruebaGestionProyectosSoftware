namespace GestionTareasSoftware.Api.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string NombreProyecto { get; set; }
        public string Descripcion { get; set; }

        public List<UsuarioProyecto>? UsuarioProyectos { get; set; }

        public List<Tarea>? Tareas { get; set; } = new List<Tarea>();
        
    }
}

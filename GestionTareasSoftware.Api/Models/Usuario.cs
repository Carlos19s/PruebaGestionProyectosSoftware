using System.Text.Json.Serialization;

namespace GestionTareasSoftware.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public List<UsuarioProyecto>? usuarioProyectos { get; set; }
    }
}

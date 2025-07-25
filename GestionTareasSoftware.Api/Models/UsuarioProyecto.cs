using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionTareasSoftware.Api.Models
{
    public class UsuarioProyecto
    {
        [Key]public int Id { get; set; }
        [ForeignKey("Usuario")]
        public int idUsuario { get; set; }
        [JsonIgnore]
        public Usuario? usuario { get; set; }

        [ForeignKey("Proyecto")]
        public int idProyecto { get; set; }
        [JsonIgnore]
        public Proyecto? proyecto { get; set; }

    }
}

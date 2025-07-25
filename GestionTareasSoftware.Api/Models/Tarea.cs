using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionTareasSoftware.Api.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombretarea { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        [ForeignKey("Proyecto")]
        public int idProyecto { get; set; }
        [JsonIgnore]
        public Proyecto? proyecto { get; set; }

    }
}

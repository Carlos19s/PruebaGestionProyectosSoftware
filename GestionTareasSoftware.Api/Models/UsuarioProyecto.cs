using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTareasSoftware.Api.Models
{
    public class UsuarioProyecto
    {
        [Key]public int Id { get; set; }
        [ForeignKey("Usuario")]
        public int idUsuario { get; set; }
        public Usuario? usuario { get; set; }

        public int idProyecto { get; set; }
        [ForeignKey("Proyecto")]
        public Proyecto? proyecto { get; set; }

    }
}

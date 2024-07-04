using System.ComponentModel.DataAnnotations;

namespace InscripcionAppMVC.Models
{
    public class Programa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }
    }
}

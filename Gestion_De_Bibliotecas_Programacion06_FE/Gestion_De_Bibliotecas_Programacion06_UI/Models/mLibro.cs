using System.ComponentModel.DataAnnotations;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Models
{
    public class mLibro
    {
        [Key]
        [Display(Name = "ID Libro")]
        public int TnIdLibro { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        [Display(Name = "ID del Autor")]
        public int? TnIdAutor { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [Display(Name = "Título")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string TcTitulo { get; set; } = null!;

        [Required(ErrorMessage = "La editorial es obligatoria")]
        [Display(Name = "Editorial")]
        [StringLength(100)]
        public string TcEditorial { get; set; } = null!;

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [Display(Name = "Categoría")]
        [StringLength(100)]
        public string TcCategoria { get; set; } = null!;

        public virtual ICollection<mPrestamo> TbiblioPrestamos { get; set; } = new List<mPrestamo>();

        [Display(Name = "Autor")]
        public virtual mAutor? TnIdAutorNavigation { get; set; }
    }
}

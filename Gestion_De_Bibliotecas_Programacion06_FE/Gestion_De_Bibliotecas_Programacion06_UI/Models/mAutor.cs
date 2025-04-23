using System.ComponentModel.DataAnnotations;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Models
{
    public class mAutor
    {
        [Key]
        [Display(Name = "ID Autor")]
        public int TnIdAutor { get; set; }

        [Required(ErrorMessage = "El nombre del autor es obligatorio")]
        [Display(Name = "Nombre del Autor")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string TcNombre { get; set; } = null!;

        [Required(ErrorMessage = "La nacionalidad es obligatoria")]
        [Display(Name = "Nacionalidad")]
        [StringLength(50, ErrorMessage = "La nacionalidad no puede superar los 50 caracteres")]
        public string TcNacionalidad { get; set; } = null!;

        
        public virtual ICollection<mLibro> TbiblioLibros { get; set; } = new List<mLibro>();
    }
}

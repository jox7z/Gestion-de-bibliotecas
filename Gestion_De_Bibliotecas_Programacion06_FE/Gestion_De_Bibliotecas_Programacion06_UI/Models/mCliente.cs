using System.ComponentModel.DataAnnotations;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Models
{
    public class mCliente
    {
        [Key]
        [Display(Name = "ID Cliente")]
        public int TnIdCliente { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string TcNombre { get; set; } = null!;

        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        [Display(Name = "Primer Apellido")]
        [StringLength(100)]
        public string TcAp1 { get; set; } = null!;

        [Display(Name = "Segundo Apellido")]
        [StringLength(100)]
        public string? TcAp2 { get; set; }

        [Display(Name = "Número de Teléfono")]
        [Phone(ErrorMessage = "Número de teléfono no válido")]
        public string? TcNumTelefono { get; set; }

        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        public string? TcCorreoElectronico { get; set; }

        public virtual ICollection<mPrestamo> TbiblioPrestamos { get; set; } = new List<mPrestamo>();
    }
}

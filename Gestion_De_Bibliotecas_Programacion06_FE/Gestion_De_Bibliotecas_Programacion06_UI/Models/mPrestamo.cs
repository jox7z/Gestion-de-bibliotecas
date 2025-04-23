using System.ComponentModel.DataAnnotations;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Models
{
    public class mPrestamo
    {
        [Key]
        [Display(Name = "ID Prestamo")]
        public int TnIdPrestamo { get; set; }

        [Required(ErrorMessage = "El ID del libro es obligatorio")]
        [Display(Name = "ID del Libro")]
        public int? TnIdLibro { get; set; }

        [Required(ErrorMessage = "El ID del cliente es obligatorio")]
        [Display(Name = "ID del Cliente")]
        public int? TnIdCliente { get; set; }

        [Required(ErrorMessage = "La fecha de préstamo es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Préstamo")]
        public DateTime TfFecPrestamo { get; set; }

        [Required(ErrorMessage = "La fecha de devolución es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Devolución")]
        public DateTime TfFecDevolucion { get; set; }

        [Display(Name = "Cliente")]
        public virtual mCliente? TnIdClienteNavigation { get; set; }

        [Display(Name = "Libro")]
        public virtual mLibro? TnIdLibroNavigation { get; set; }
    }
}

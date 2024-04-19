using System.ComponentModel.DataAnnotations;
using RegistroHoras.Data;


namespace RegistroHoras.Models{

    public class Registro
    {
        [Key]
        public int Id { get; set; }
        public TimeSpan? Hora_Salida { get; set; }
        public TimeSpan? Hora_Entrada { get; set; }
        public DateOnly Fecha_Salida { get; set; }
        public DateOnly Fecha_Entrada { get; set; }
        public int? EmpleadoId { get; set; } 

    }
}
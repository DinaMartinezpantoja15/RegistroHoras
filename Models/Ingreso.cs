using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroHoras.Models
{
    public class Ingreso
    {
        public int Id { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Hora_Ingreso { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha_Ingreso { get; set; }
    }
}

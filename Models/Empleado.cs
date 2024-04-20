using System.ComponentModel.DataAnnotations;


namespace RegistroHoras.Models

{
    public class Empleado
    {
      [Key]
      public int Id { get; set; }
      public string? Nombre { get; set; }
      public string? Apellido { get; set; }
      public string? Tipo_documento { get; set; }
      public string? Numero_documento { get; set; }
      public string? Area { get; set; }
      public string? Cargo { get; set; }
      public string? Contraseña { get; set; }

  }

}
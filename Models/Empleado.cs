namespace RegisroIngresos.Models

{
    public class Empleado
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Tipo_documento  { get; set; }
        public string? Numero_documento { get; set; }
        public int? Cargo { get; set; }
        public int? Area { get; set; }
        public string? Contraseña { get; set; }


    }

}
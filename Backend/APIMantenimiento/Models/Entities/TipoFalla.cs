namespace APIMantenimiento.Models.Entities
{
    public class TipoFalla
    {
        public long Id { get; set; }
        public string Nombre {get; set;}
        public string? Descripcion {get; set;}
        public string NombreIngreso {get; set;}
        public DateTime FechaIngreso {get; set;}
        public string? NombreActualizacion {get; set;}
        public DateTime? FechaActualizacion {get; set;}
    }
}

namespace APIMantenimiento.Models.DTOs.Client
{
    public class TipoFallaDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        /*se le pone el simbolo del operador ternario para que nos deje ponerle valores nulos o null*/
        public string NombreIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        //public string? NombreActualizacion { get; set; }
        //public DateTime? FechaActualizacion { get; set; }
    }
}

using System.Text.Json;

namespace APIMantenimiento.Models.DTOs
{
    public class HttpErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Description { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? StackTrace { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

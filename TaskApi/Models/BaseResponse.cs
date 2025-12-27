using Microsoft.AspNetCore.Mvc.Formatters;

namespace TaskApi.Models
{
    public class BaseResponse<T>
    {
        public int Status { get; set;}
        public string Message { get; set; } = string.Empty;
        public T? Payload { get; set; } 

        // Constructor para respuestas exitosas
        public BaseResponse(T payload, string message = "Operación exitosa")
        {
            Status = 200;
            Message = message;
            Payload = payload;
        }

        // Constructor para errores (Bonus: Manejo de errores HTTP)
        public BaseResponse(int status, string message)
        {
            Status = status;
            Message = message;
            Payload = default;
        }


    }
    
}
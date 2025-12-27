using Microsoft.AspNetCore.Mvc.Formatters;

namespace TaskApi.Models
{
    public class TaskItem
    {
        public int Id{get; set;} //numero de la tarea
        public string Title {get; set;} = string.Empty; //Texto de la tarea
        public bool IsCompleted {get; set;} //Si está hecha o no
        public DateTime CreatedAt {get; set;} =DateTime.UtcNow; //cuando se creó
    }
}


using System.Linq;
using TaskApi.Models;
using Microsoft.Extensions.Logging;

namespace TaskApi.Services;

public class TaskService
{
    //Guarda tareas en memoria
    private readonly List<TaskItem> _tasks = new();
    private readonly ILogger<TaskService> _logger;

    public TaskService(ILogger<TaskService> logger)
    {
        _logger = logger;
    }
    private int _nextId = 1;

    public GenericResponse <List<TaskItem>> GetAll()
    {
        GenericResponse <List<TaskItem>> response = new ();
      try
      {  
        
         response.Status=200;
            response.message ="Consultado con exito"; 
            response.Payload = _tasks;
            _logger.LogInformation("Consultando la lista de tareas  a las {DT}", DateTime.UtcNow.ToLongTimeString());
        return response;
        }
      catch (Exception e)
        {
             response.Status=400;
            response.message ="No fue posible realizar la operación"; 
            response.Payload = new();
             _logger.LogError("No fue posible realizar la operación debido a: {}", e);
             return response;
        }
    }

    //Crea nuevas tareas
    public GenericResponse <TaskItem> Create(string title, string comments)
    {
        GenericResponse <TaskItem> response = new ();
        try
        {
             var task = new TaskItem
        {
            Id = _nextId++,
            Title = title,
            Comments = comments,
            IsCompleted = false
        };

        _tasks.Add(task);
         response.Status=200;
            response.message ="Creado con exito"; 
            response.Payload = task;
             _logger.LogInformation("Se ha creado con exito la tarea {} con los comentarios {} a las {DT}",title,comments, DateTime.UtcNow.ToLongTimeString());
        return response;
        }
        catch (Exception e)
        {
            response.Status=400;
            response.message ="No fue posible realizar la operación"; 
            response.Payload = new();
             _logger.LogError("No fue posible realizar la operación debido a: {}", e);
             return response;
        }

    }

    //marca tareas como completadas
   public GenericResponse<bool> Complete(int id)
{
    GenericResponse<bool> response = new();
    var task = _tasks.FirstOrDefault(t => t.Id == id);
    
    if (task == null) {
        response.Status = 404;
        response.Payload = false;
        response.message= "No se encontró el registro";
        _logger.LogWarning("No se encontró el registro");
        return response;
    }

    // INVERTIR EL ESTADO: Si es true pasa a false, si es false a true
    task.IsCompleted = !task.IsCompleted; 
    
    response.Status = 200;
    response.Payload = task.IsCompleted; // Devolvemos el nuevo estado
    response.message="Estado actualizado";
    _logger.LogInformation("Se cambiado con exito el estatus de la tarea {} a las {DT}",id, DateTime.UtcNow.ToLongTimeString());
    return response;
}
}
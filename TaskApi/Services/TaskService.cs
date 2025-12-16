using System.Linq;
using TaskApi.Models;

namespace TaskApi.Services;

public class TaskService
{
    //Guarda tareas en memoria
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public GenericResponse <List<TaskItem>> GetAll()
    {
        GenericResponse <List<TaskItem>> response = new ();
      try
      {  
         response.Status=200;
            response.message ="Consultado con exito"; 
            response.Payload = _tasks;
        return response;
        }
      catch(Exception ex)
        {
             response.Status=400;
            response.message ="No fue posible realizar la operación"; 
            response.Payload = new();
             return response;
        }
    }

    //Crea nuevas tareas
    public GenericResponse <TaskItem> Create(string title)
    {
        GenericResponse <TaskItem> response = new ();
        try
        {
             var task = new TaskItem
        {
            Id = _nextId++,
            Title = title,
            IsCompleted = false
        };

        _tasks.Add(task);
         response.Status=200;
            response.message ="Creado con exito"; 
            response.Payload = task;
        return response;
        }
        catch
        {
            response.Status=400;
            response.message ="No fue posible realizar la operación"; 
            response.Payload = new();
             return response;
        }

    }

    //marca tareas como completadas
    public GenericResponse <bool> Complete (int id)
    {
        GenericResponse <bool> response = new ();
        try
        {
             var task = _tasks.FirstOrDefault(t => t.Id ==id);
             if (task == null)
            {
                response.Status=404;
            response.message ="No se encontró el registro"; 
            response.Payload = false;
            return response;
            }
            
            task.IsCompleted = true;
            
            response.Status=200;
            response.message ="Actualizado con exito"; 
            response.Payload = true;
            return response;
        }
        catch
        {
            response.Status=400;
            response.message ="No fue posible actualizarlo"; 
            response.Payload = false;
            return response;
        }
    }
}

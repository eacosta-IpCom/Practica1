public class GenericResponse<T> //Insertar dato generico
{
    public int Status {get; set;}
    public string message {get; set;} = string.Empty;
    public T Payload {get; set;} //Payload puede valer lo que quiera

}

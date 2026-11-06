using System.Text.Json.Serialization;

public class Tarea
{
    [JsonInclude]
    public int Id {get; private set; }
    [JsonInclude]
    public string Titulo { get; private set; }
    [JsonInclude]
    public bool Completada { get; private set; }
    [JsonInclude]
    public DateTime Fecha {get; private set;}
 
 
    public Tarea(int id, string titulo, DateTime fecha)
    {
        this.Id = id;
        this.Titulo = titulo;
        this.Completada = false;
        this.Fecha = fecha;
    }
    
    public void MarcarCompletada()
    {
        this.Completada = true;
    }

    [JsonConstructor] // Atributo para indicar que este constructor se utilizará durante la deserialización
    private Tarea()=> Titulo = string.Empty; // Constructor privado para la deserialización
    
}
public class Tarea
{
    public int Id {get; private set; }
    public string Titulo { get; private set; }
    public bool Completada { get; private set; }
    public DateTime Fecha {get; private set;}
 
    public Tarea(int id, string titulo, bool completada, DateTime fecha)
    {
        this.Id = id;
        this.Titulo = titulo;
        this.Completada = completada;
        this.Fecha = fecha;
    }
    
    public void MarcarCompletada()
    {
        this.Completada = true;
    }
}
public class Tarea
{
    private int id {get; set;}
    private string titulo { get; set; }
    private bool completada { get; set; }
    private DateTime fecha {get; set;}
 
    public Tarea(int id, string titulo, bool completada, DateTime fecha)
    {
        this.id = id;
        this.titulo = titulo;
        this.completada = completada;
        this.fecha = fecha;
    }
     public int setId()
    {
        return id;
    }

    public string setTitulo()
    {
        return titulo;
    }

    public bool setCompletada()
    {
        return completada;
    }

    public DateTime setFecha()
    {
        return fecha;
    }
    
    public void marcarCompletada()
    {
        this.completada = true;
    }
}
public class GestorTarea
{
    private int _siguienteId => _tareas.Count > 0 ? _tareas.Max(t => t.Id) + 1 : 1;
    private const string Ruta = "tareas.json";
    private List<Tarea> _tareas = AlmacenamientoJson.CargarTareas(Ruta);

    public string Agregar(string titulo)
    {
        DateTime fechaCreada = DateTime.Now;
        Tarea t = new Tarea(_siguienteId, titulo, fechaCreada);
        _tareas.Add(t);
        Console.ForegroundColor = ConsoleColor.Green;
        AlmacenamientoJson.GuardarTareas(Ruta, _tareas); 
        return "Tarea agregada";
    }

    public string Listar()
    {
        if (_tareas.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Lo sentimos, no contiene tareas.";
        }
        else
        {
           foreach (Tarea tarea in _tareas)
          {
              Console.WriteLine($"ID: {tarea.Id} ");
              Console.WriteLine($"Titulo: {tarea.Titulo}");
              Console.WriteLine($"Fecha de creación: {tarea.Fecha:dd/MM/yyyy HH:mm}");
              Console.WriteLine($"Completada: {tarea.Completada}");
              
          }
          Console.WriteLine("");
        }

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Green;
        AlmacenamientoJson.GuardarTareas(Ruta, _tareas); 
        return "Listado completado";
    }

   public string Eliminar(int idBuscar)
    {
        Tarea? Buscartarea = _tareas.Find(t => t.Id == idBuscar);
        if (Buscartarea != null)
        {
            _tareas.Remove(Buscartarea);
            Console.ForegroundColor = ConsoleColor.Green;
            AlmacenamientoJson.GuardarTareas(Ruta, _tareas);
            return "Tarea eliminada";
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Tarea no encontrada";
        }
    }

    public string Completar(int idBuscar)
    {
        Tarea? BuscaTarea = _tareas.Find(tb => tb.Id == idBuscar);
        
        if(BuscaTarea != null)
        {
           if (BuscaTarea.Completada)
           {
             Console.ForegroundColor = ConsoleColor.Yellow;
             return "Advertencia: Esta tarea está completada.";
           }
           Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            BuscaTarea.MarcarCompletada();
            AlmacenamientoJson.GuardarTareas(Ruta, _tareas);
            return "Tarea Completada";
        }
        else 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Lo sentimos, esta tarea no existe";
        }
    }


}
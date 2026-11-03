public class GestorTarea
{
    private int id_Auto = 1;
    List <Tarea> tareas = new List<Tarea>();

     public string agregar(string titulo, bool completada)
     {
        DateTime fechaCreada = DateTime.Now;
        Tarea t = new Tarea(id_Auto,titulo, completada, fechaCreada);
        tareas.Add(t);
        Console.ForegroundColor = ConsoleColor.Green;
        id_Auto++;
        return "Tarea agregada";
     }

     public string listar()
    {
        if (tareas.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Lo sentimos, no contiene tareas.";
        }
        else
        {
           foreach (Tarea tarea in tareas)
          {
              Console.WriteLine($"ID: {tarea.Id} ");
              Console.WriteLine($"Titulo: {tarea.Titulo}");
              Console.WriteLine($"Fecha de creación: {tarea.Fecha:dd/MM/yyyy HH:mm}");
              Console.WriteLine($"Completada: {tarea.Completada}");
              Console.WriteLine("--------------------");
          }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        return "Listado completado";
       
    }

   public string eliminar(int id_Buscar)
    {
        Tarea ? Buscartarea = tareas.Find(t => t.Id == id_Buscar);
        if (Buscartarea != null)
        {
            tareas.Remove(Buscartarea);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Tarea eliminada";
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return "Tarea no encontrada";
        }
    }

    public string completar(int id_Buscar)
    {
        Tarea ? BuscaTarea = tareas.Find(tb => tb.Id == id_Buscar);
        
        if(BuscaTarea != null)
        {
           if (BuscaTarea.Completada)
           {
             Console.ForegroundColor = ConsoleColor.Yellow;
             return "Advertencia: Esta tarea está completada.";
           }
           
            Console.ForegroundColor = ConsoleColor.Green;
            BuscaTarea.MarcarCompletada();
            return "Tarea Completada";

            
        }
        else 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Lo sentimos, esta tarea no existe";
        }

       
    }
     
}
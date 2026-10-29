// Cuando el método sea static string, es de devolver mensajes o información relacionada con el método Main.
// Cuando el método sea static int, es de cálculos numéricos o validaciones que devuelven un número entero.
// Cuando el método sea static bool, es de validaciones que devuelven verdadero o falso.

// Recordar todos los conceptos aprendidos y hacer programas más grandes y complejos.
// if-else, switch - case, switch - when, while, do-while, for, foreach, arrays, métodos, clases POO básico, instancia de objetos, try-catch, etc.

// Orden alfabético de Variables.

// Ejercicio 3

int opcion = 0, id_Buscar = 0;
string titulo = "";
bool completada = false, salir = true;
DateTime fecha = DateTime.Now;

GestorTareas gestorT = new GestorTareas();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Bienvenido al gestor de tareas");
Console.WriteLine("A continuación verás el menú de opciones");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.White;

while (salir)
{ 

   Console.WriteLine("==== MENÚ DE OPCIONES ====");
   Console.WriteLine("Ingrese una opción: ");
   Console.WriteLine("1. Agregar tarea"); 
   Console.WriteLine("2. Listar tareas");
   Console.WriteLine("3. Completar tarea");
   Console.WriteLine("4. Eliminar Tarea");
   Console.WriteLine("===========================");
   
   Console.WriteLine("");
   Console.Write("Opción: ");

   while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: Por favor ingresa una opción válida.");
        Console.ForegroundColor =  ConsoleColor.White;
        Console.WriteLine("");
        Console.Write(">> ");
        
    }
    
   Console.Clear();
    
  switch (opcion)
  {
      case 1:
      Console.WriteLine("== AGREGAR TAREA ==");
      Console.WriteLine("Ingrese el título de la tarea: ");
      titulo = Console.ReadLine() ?? "";
      Console.WriteLine("");
      while (string.IsNullOrWhiteSpace(titulo)|| titulo.Any(char.IsDigit))
      {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Error: Solo está permitido caracteres");
          Console.Write(">> ");
          Console.ForegroundColor = ConsoleColor.White;
          titulo = Console.ReadLine() ?? "";
      }
      
      Console.WriteLine("Ingrese si la tarea está completada (True/False):");
      while (!bool.TryParse(Console.ReadLine(), out completada))
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine ("Error: formato inválido");
        Console.ForegroundColor = ConsoleColor.White;
      }

      
      Console.WriteLine(gestorT.agregar(titulo, completada));
      break;

      case 2:
      Console.WriteLine("== LISTAR TAREA ==");
      Console.WriteLine("A continuación verá la lista de tareas creadas.");
      Console.WriteLine(gestorT.listar());
      break;

      case 3:
      Console.WriteLine("== COMPLETAR TAREA ==");
      Console.WriteLine("Busca la tarea que deseas completar por su ID");
      while(!int.TryParse(Console.ReadLine(), out id_Buscar))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo es permitido valores numéricos.");
            }
      Console.WriteLine(gestorT.completar(id_Buscar));
      break;

      case 4:
      Console.WriteLine("== ELIMINAR TAREA ==");
      Console.WriteLine("Ingresa el ID de la tarea para ser eliminada");
      while(!int.TryParse(Console.ReadLine(), out id_Buscar))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo es permitido valores numéricos.");
            }
      Console.WriteLine(gestorT.eliminar(id_Buscar));
      break;
  }

  Console.WriteLine("");
  Console.ForegroundColor = ConsoleColor.Yellow;
  Console.WriteLine("¿Deseas volver al principio? Puedes escribir 'S/N'.");
  string respuesta = Console.ReadLine()?.Trim().ToUpper()?? "";
  Console.ForegroundColor =  ConsoleColor.White;
  Console.WriteLine("");

  while (respuesta != "S" && respuesta != "N")    
   {   Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Error: Es válido S o N.");
      Console.ResetColor();
      Console.WriteLine (">>:");
      respuesta = Console.ReadLine()?.Trim().ToUpper()?? "";
   }

  salir = respuesta == "S";

  Console.Clear();
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Muchas gracias por utilizar el gestor de tareas.");
Console.WriteLine("¡ Hasta Luego !");
Console.ForegroundColor = ConsoleColor.White;


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

public class GestorTareas
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
              Console.WriteLine($"ID: {tarea.setId()} ");
              Console.WriteLine($"Titulo: {tarea.setTitulo()}");
              Console.WriteLine($"Fecha de creación: {tarea.setFecha(): dd/MM/yyyy HH:mm}");
              Console.WriteLine($"Completada: {tarea.setCompletada()}");
              Console.WriteLine("--------------------");
          }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        return "Listado completado";
       
    }

   public string eliminar(int id_Buscar)
    {
        Tarea ? Buscartarea = tareas.Find(t => t.setId() == id_Buscar);
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
        Tarea ? BuscaTarea = tareas.Find(tb => tb.setId() == id_Buscar);
        
        if(BuscaTarea != null)
        {
           if (BuscaTarea.setCompletada())
           {
             Console.ForegroundColor = ConsoleColor.Yellow;
             return "Advertencia: Esta tarea está completada.";
           }
           
            Console.ForegroundColor = ConsoleColor.Green;
            BuscaTarea.marcarCompletada();
            return "Tarea Completada";

            
        }
        else 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Lo sentimos, esta tarea no existe";
        }

       
    }
     
}
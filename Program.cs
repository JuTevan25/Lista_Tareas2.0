int opcion = 0, id_Buscar = 0;
string titulo = "";
bool salir = true;
DateTime fecha = DateTime.Now;

GestorTarea gestorT = new GestorTarea();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Bienvenido al gestor de tareas");
Console.WriteLine("A continuación verás el menú de opciones");
Console.WriteLine("");
Console.ResetColor();

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
        Console.ResetColor();
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
          Console.ResetColor();
          titulo = Console.ReadLine() ?? "";
      }
    
      Console.WriteLine(gestorT.agregar(titulo));
      break;

      case 2:
      Console.WriteLine("== LISTAR TAREA ==");
      Console.WriteLine("A continuación verá la lista de tareas creadas: ");
      Console.WriteLine("=========================");
      Console.WriteLine(gestorT.listar());
      Console.WriteLine("=========================");
      break;

      case 3:
      Console.WriteLine("== COMPLETAR TAREA ==");
      Console.WriteLine("Busca la tarea que deseas completar por su ID: ");
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
  Console.ResetColor();
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
Console.ResetColor();

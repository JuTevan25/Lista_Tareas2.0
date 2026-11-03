int opcion = 0, idBuscar = 0;
string titulo = "";
bool salir = true;

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
        Console.WriteLine("");
        Console.Write(">> ");
        Console.ResetColor();
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
          Console.WriteLine("Error: El título no puede estar vacío ni contener números");
          Console.Write(">> ");
          Console.ResetColor();
          titulo = Console.ReadLine() ?? "";
      }
    
      Console.WriteLine(gestorT.Agregar(titulo));
      break;

      case 2:
      Console.WriteLine("== LISTAR TAREA ==");
      Console.WriteLine("A continuación verá la lista de tareas creadas: ");
      Console.WriteLine("=========================");
      Console.WriteLine(gestorT.Listar());
      Console.WriteLine("=========================");
      break;

      case 3:
      Console.WriteLine("== COMPLETAR TAREA ==");
      Console.WriteLine("Busca la tarea que deseas completar por su ID: ");
      while(!int.TryParse(Console.ReadLine(), out idBuscar))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo es permitido valores numéricos.");
                Console.ResetColor();
            }
      Console.WriteLine(gestorT.Completar(idBuscar));
      break;

      case 4:
      Console.WriteLine("== ELIMINAR TAREA ==");
      Console.WriteLine("Ingresa el ID de la tarea para ser eliminada");
      while(!int.TryParse(Console.ReadLine(), out idBuscar))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo es permitido valores numéricos.");
                Console.ResetColor();
            }
      Console.WriteLine(gestorT.Eliminar(idBuscar));
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
      Console.WriteLine (">>:");
      Console.ResetColor();
      respuesta = Console.ReadLine()?.Trim().ToUpper()?? "";
   }

  salir = respuesta == "S";

  Console.Clear();
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Muchas gracias por utilizar el gestor de tareas.");
Console.WriteLine("¡ Hasta Luego !");
Console.ResetColor();
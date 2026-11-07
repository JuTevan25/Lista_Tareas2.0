using System.Text.Json;

public class AlmacenamientoJson
{
    private static readonly JsonSerializerOptions _opciones = new JsonSerializerOptions // Configuración de serialización
    { 
        WriteIndented = true // Formato legible para humanos
    };

    public static void GuardarTareas(string ruta, List<Tarea> tareas)
    {
        string json = JsonSerializer.Serialize(tareas, _opciones);
        File.WriteAllText(ruta, json);
    }

    public static List<Tarea> CargarTareas(string ruta) // Método para cargar tareas desde un archivo JSON
    {
        try
        {
            if (File.Exists(ruta))
            {
                string texto = File.ReadAllText(ruta);
                return JsonSerializer.Deserialize<List<Tarea>>(texto) ?? new List<Tarea>();
            }
        }
        catch (JsonException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error al cargar las tareas: {ex.Message}");
            Console.ResetColor();
            File.Copy(ruta, ruta + ".bak", true);
        }

        return new List<Tarea>();
    }
}

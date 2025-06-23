internal class Program
{
    private static void Main(string[] args)
    {
        string path;
        do
        {
            Console.WriteLine("Ingrese la ruta del directorio ");
            path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Error no existe el directorio");
                Console.WriteLine("Ingrese nuevamente");
            }
        } while (!Directory.Exists(path));

        Console.WriteLine("Carpetas en el directorio");
        
        var directorios = Directory.GetDirectories(path);
        if (directorios.Length > 0)
        {
            foreach (var item in directorios)
            {
                string nombreCarpeta = Path.GetFileName(item);
                Console.WriteLine(nombreCarpeta);
            }
        }else
        {
            Console.WriteLine($"El directorio {path} no contiene subdirectorios");
        }
        
        Console.WriteLine("Archivos en el directorio");

        string[] archivos = Directory.GetFiles(path);
        if (archivos.Length > 0)
        {
            foreach (var item in archivos)
            {
                FileInfo info = new FileInfo(item);
                double tamaOr = info.Length / 1024.0;
                Console.WriteLine($"{info.Name} - {tamaOr} KB");
            }
            string path_file = "reporte_archivos.csv";
            string path_reporte = Path.Combine(path, path_file);
            using (var stream = new StreamWriter(path_reporte))
                {
                    stream.WriteLine($"Archivo - Tama en KB - Ultima modificacion");
                    foreach (var item in archivos)
                    {
                        string nombre = Path.GetFileName(item);
                        var info = new FileInfo(item);
                        var length = info.Length / 1024.0;
                        var date = info.LastWriteTime;
                        stream.WriteLine($"{nombre} - {length} - {date}");
                    }
                }
            }
        else
        {
            Console.WriteLine($"El directorio {path} no contiene archivos");
        }
        
    }
    
}
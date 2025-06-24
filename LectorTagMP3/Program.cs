using LectorTagMP3;
internal class Program
{
    private static void Main(string[] args)
    {
        string ruta;
        do
        {
            Console.WriteLine("Ingrese la ruta del archivo MP3 ");
            ruta = Console.ReadLine();

            if (!File.Exists(ruta))
            {
                Console.WriteLine("Archivo no encontrado");
                Console.WriteLine("Ingrese nuevamente");
            }
        }while (!File.Exists(ruta));
        
        using (var file = new FileStream(ruta, FileMode.Open, FileAccess.Read))
        {
            file.Position = file.Length - 128;
            byte[] buffer = new byte[128];
            file.Read(buffer, 0, 128);

            string header = System.Text.Encoding.ASCII.GetString(buffer, 0, 3);

            if (header != "TAG")
            {
                Console.WriteLine("El archivo no contiene una etiqueta Id3v1");
                return;
            }

            string titulo = System.Text.Encoding.ASCII.GetString(buffer, 3, 30);
            string artista = System.Text.Encoding.ASCII.GetString(buffer, 33, 30);
            string album = System.Text.Encoding.ASCII.GetString(buffer, 63, 30);
            string anio = System.Text.Encoding.ASCII.GetString(buffer, 93, 4);

            var mp3 = new Mp3(titulo, artista, album, anio);

            Console.WriteLine($"Título: {mp3.titulo}");
            Console.WriteLine($"Artista: {mp3.artista}");
            Console.WriteLine($"Álbum: {mp3.album}" );
            Console.WriteLine($"Año: {mp3.anio}" );
        }
    }
}
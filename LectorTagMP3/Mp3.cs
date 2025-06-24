namespace LectorTagMP3;

public class Mp3
{
    public string titulo { get; set; }
    public string artista { get; set; }
    public string album { get; set; }
    public string anio { get; set; }
    public Mp3(string titulo, string artista, string album, string anio)
    {
        this.titulo = titulo;
        this.artista = artista;
        this.album = album;
        this.anio = anio;
    }
}

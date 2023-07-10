namespace crudbuku.Models;

public class Buku
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Penerbit { get; set; }
    public long TahunTerbit { get; set; }
}
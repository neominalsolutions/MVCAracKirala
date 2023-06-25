namespace AracKirala.Data.Entities
{
  public class Sirket
  {
    public int Id { get; set; }
    public string Isim { get; set; }
    public string Adres { get; set; }
    public List<Arac>? Araclar { get; set; } // 1 to n bir şirketin birden fazla aracı var.


  }
}

namespace AracKirala.Data.Entities
{
  public class Musteri
  {
    public int Id { get; set; }
    public string Isim { get; set; }
    public string Telefon { get; set; }
    public string EhliyetNo { get; set; }

    public string? Adres { get; set; }


    //public List<Arac> Araclar { get; set; }

    // Bir müşteride birden fazla kez araç kiralayabilir.
    // Müşteri ile araç arasındaki çoka çok ilişkiyi araç kiralama tablosu sağlar.
    public List<AracKiralama> KiralananAraclar { get; set; } = new List<AracKiralama>();

  }
}

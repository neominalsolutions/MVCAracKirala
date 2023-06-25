

namespace AracKirala.Data.Entities
{
  public class Arac
  {
    public int Id { get; set; }

    // PK alanlar GUID olsun diye yaptık
    //public string AracId { get; set; }

    //public Arac()
    //{
    //  AracId = Guid.NewGuid().ToString();
    //}

    public string Marka { get; set; }
    public string Model { get; set; }

    public string Plaka { get; set; }

    public string Km { get; set; }

    public decimal SaatlikUcret { get; set; }

    public decimal GunlukUcret { get; set; }

    public int? SirketId { get; set; } // veri tabanında kayıt var o yüzden şirketId alanı zorunlu olmaz
    public Sirket? AracSirket { get; set; } // arac üzerinden şirket bilgisine ulaşarak ekranda göstermek için 

    public AracPolice Police { get; set; }

    // 1 araç birden fazla kez kiralanabilir.
    public List<AracKiralama> KiralananAraclar { get; set; } = new List<AracKiralama>();




  }
}

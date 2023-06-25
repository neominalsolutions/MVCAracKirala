namespace AracKirala.Data.Entities
{
  public class AracPolice
  {
    public int PoliceId { get; set; }
    public int AracId { get; set; }
    public string PoliceNumara { get; set; }

    public DateTime PoliceBaslangicTarihi { get; set; }

    public DateTime PoliceBitisTarihi { get; set; }

    public Arac Arac { get; set; }

  }
}

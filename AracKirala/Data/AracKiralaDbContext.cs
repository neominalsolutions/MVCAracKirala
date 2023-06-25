using AracKirala.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AracKirala.Data
{
  public class AracKiralaDbContext:DbContext
  {
    public DbSet<Arac> Araclar { get; set; } // araç kiralamak için tanımladığımız nesne
    public DbSet<AracPolice> AracPoliceler { get; set; } // araca ait trafik poliçeleri için tanımladığımız nesne
    public DbSet<Musteri> Musteriler { get; set; } // müşteri araç kiralaması yapmak için tanımladığımız nesne
    public DbSet<AracKiralama> KiralananAraclar { get; set; } // müşteriler tarafında berlirli tarihlerde kiralanan araçların listesi
    public DbSet<Sirket> Sirketler { get; set; } // aracın hangi şirkete ait olduğunu tuttuğumuz tablo


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=(localDB)\\MyLocalDb;Database=AracKiralaDB;Trusted_Connection=True;");

      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Fluent API Yöntemi
      // Diğer [key] Data Annotations Yöntemi
      modelBuilder.Entity<AracPolice>().HasKey(x => x.PoliceId); // PoliceId alanı PK alandır.

      //1 e 1 ilişki tanımını yapacağımız yer
      modelBuilder
        .Entity<Arac>()
        .HasOne(x=> x.Police) // aracın 1 tane poliçesi var 
        .WithOne(x=> x.Arac) // o poliçe 1 araca tanımlanmıştır
        .HasForeignKey<AracPolice>(x => x.AracId); // poliçeyi bulmak için araçId alanını kullan.


      //    modelBuilder
      //.Entity<AracPolice>()
      //.HasOne(x => x.Arac)
      //.WithOne(x => x.Police)
      //.HasForeignKey<AracPolice>(x => x.AracId);


      // şirket ile aracı bire çok ilişki tanımlayalım

      modelBuilder.Entity<Arac>()
        .HasOne(x => x.AracSirket) // aracın 1 tane şirketi olur
        .WithMany(x => x.Araclar) // o şirketin birden fazla aracı olabilir.
        .HasForeignKey(x => x.SirketId); // araç ile şirket arasında şirketId ilişkisi vardır.


      // çoka çok ilişki nasıl yazılır
      // çoka çok tablolarda her iki tabloya 1'e çok ilişki tanımlanarak çokaçok ilişki yapılır
      modelBuilder.Entity<AracKiralama>() 
        .HasOne(x => x.Arac) // 1 arac
        .WithMany(x => x.KiralananAraclar) // 1 den fazla kez kiralanabilir
        .HasForeignKey(x => x.AracId); // arac ile kiralama arasında aracıd ilişkisi vardır.

      modelBuilder.Entity<AracKiralama>()
        .HasOne(x => x.Musteri) // 1 müşteri
        .WithMany(x => x.KiralananAraclar) // 1 den fazla kez araç kiralayabilir
        .HasForeignKey(x => x.MusteriId); // musteri ile kirakama arasında musteriId ilişkisi vardır.



      base.OnModelCreating(modelBuilder);
    }
  }
}

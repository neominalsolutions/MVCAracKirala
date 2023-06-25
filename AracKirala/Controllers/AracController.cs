using AracKirala.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AracKirala.Controllers
{
  public class AracController : Controller
  {
    // /araclar
    // uygulama için controller/action dan farklı kendimize ait anlamlı urller oluşturmak için kullanılan bir teknik.
    [HttpGet("araclar-police", Name = "araclarRoute")]
    public IActionResult AracPolicleriIleBirlikte()
    {
      // 1 to 1 ilişikiye ait view yaptık.
      var db = new AracKiralaDbContext();
      var araclar = db.Araclar.Include(x => x.Police).ToList();
      // araç ile poliçeyi joinledik çünkü aracın poliçesinide ekranda göstermek istiyorum.
      // ilişki tablodan veri çekmek için include methodunu kullanıp ilişki ismini yazıyorz.

      return View(araclar);
    }

    // /araclar-sirket (url)
    [HttpGet("araclar-sirket", Name ="araclarSirketRoute")]
    public IActionResult AraclarıSirketleriIleGoster()
    {
      var db = new AracKiralaDbContext();
      var araclar = db.Araclar.Include(x => x.AracSirket).OrderByDescending(x => x.SaatlikUcret).ToList(); // araçları şirketleri ile birlite getir.

      return View(araclar);
    }

  }
}

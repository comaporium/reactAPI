using Microsoft.AspNetCore.Mvc;
using zadaci.Models;

namespace zadaci.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ZadaciController : Controller
    {
        ZadaciContext db = new ZadaciContext();

        [HttpGet]
        public IActionResult sviZadaci()
        {
            List<Zadaci> sviZadaci = db.Zadacis.OrderBy(x => x.Id).ToList();
            return Ok(sviZadaci);
        }

        [HttpPost]
        public IActionResult dodajZadatak(string nazivZadatka)
        {
            Zadaci noviZadatak = new Zadaci();
            noviZadatak.NazivZadatka = nazivZadatka;

            db.Add(noviZadatak);
            db.SaveChanges();

            return Ok(noviZadatak);
        }

        [HttpPut("{id}")]
        public IActionResult azurirajZadatak(int id)
        {
            Zadaci zadatak = db.Zadacis.Where(x => x.Id == id).FirstOrDefault();   
            
            zadatak.Stanje = (byte?)(zadatak.Stanje == 0 ? 1 : 0);

            db.SaveChanges();
            return Ok(zadatak);
        }

        [HttpDelete("{id}")]
        public IActionResult obrisiZadatak(int id)
        {
            Zadaci zadatak = db.Zadacis.Where(x => x.Id == id).FirstOrDefault();
            if (zadatak == null) return NotFound("Ne postoji zadatak sa tim IDem");
            db.Remove(zadatak);
            db.SaveChanges();

            return Ok(zadatak);
        }
    }
}

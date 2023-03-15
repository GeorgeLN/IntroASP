using IntroASP.Models;
using IntroASP.Models.ViewModels.BeerModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubContext _context;

        public BeerController(PubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var beers = _context.Beers.Include(b => b.Brand);
            return View(await beers.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View();
        }

        public IActionResult Delete()
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Permite esperar si o si la información del formulario que está en el mísmo dominio del sitio... Con eso se evita el envío de información por parte de otros sitios.
        public async Task<IActionResult> Create(BeerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var beer = new Beer()
                    {
                        Name = model.Name,
                        BrandId = model.BrandId
                    };
                    _context.Add(beer); //Para agregar a la base de datos.
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.BrandId);
            return View();
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(ClientDeleteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = new Client()
                    {
                        Id = model.Id
                    };
                    _context.Remove(client); //Para remover/eliminar de la base de datos
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            // ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.Id);
            return View();
        }
        */
    }
}

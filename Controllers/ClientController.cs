using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class ClientController : Controller
    {
        private readonly PubContext _context;

        public ClientController(PubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Clients"] = new SelectList(_context.Clients, "Id", "Name");
            return View();
        }

        public IActionResult Delete()
        {
            ViewData["Clients"] = new SelectList(_context.Clients, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Permite esperar si o si la información del formulario que está en el mísmo dominio del sitio... Con eso se evita el envío de información por parte de otros sitios.
        public async Task<IActionResult> Create(ClientViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = new Client()
                    {
                        Id = model.Id,
                        Name = model.Name
                    };
                    _context.Add(client); //Para agregar a la base de datos.
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            ViewData["Clients"] = new SelectList(_context.Clients, "Id", "Name", model.Id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ClientDeleteModel model)
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
    }
}

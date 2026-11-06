using Microsoft.AspNetCore.Mvc;
using Veterinaria.Entidades;
using Veterinaria.Negocios;

namespace Veterinaria.Web.Controllers
{
    public class MascotasController : Controller
    {
        private readonly MascotaService _mascotaService;

        public MascotasController(MascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        // GET: Mascotas
        public IActionResult Index()
        {
            var mascotas = _mascotaService.ObtenerTodas();
            return View(mascotas);
        }

        // GET: Mascotas/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Mascotas/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Mascota mascota)
        {
            try
            {
                _mascotaService.RegistrarMascota(mascota);
                TempData["Mensaje"] = "¡Mascota guardada con éxito en SQL Server!";
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(mascota);
            }
        }
    }
}
using InscripcionAppMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InscripcionAppMVC.Controllers
{
    public class InformacionController : Controller
    {
        private readonly AppDbContext _context;

        public InformacionController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Inscripciones()
        {
            var inscripciones = await _context.Inscripciones
            .Include(i => i.Aspirante)
            .Include(i => i.TipoAspirante)
            .Include(i => i.Programa)
            .ToListAsync();

            return View(inscripciones);

        }

        public async Task<IActionResult> Aspirante(int id)
        {
            var aspirante = await _context.Inscripciones
            .Include(i => i.Aspirante)
            .Include(i => i.TipoAspirante)
            .Include(i => i.Programa)
            .FirstOrDefaultAsync(a => a.AspiranteId == id);

            return View(aspirante);
        }
    }
}

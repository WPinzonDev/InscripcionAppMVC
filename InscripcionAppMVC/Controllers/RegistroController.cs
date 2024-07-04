using Microsoft.AspNetCore.Mvc;
using InscripcionAppMVC.Data;
using InscripcionAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InscripcionAppMVC.Controllers
{
    public class RegistroController : Controller
    {
        private readonly AppDbContext _context;

        public RegistroController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            await CargarDatosRegistro();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MatricularAspirante(Inscripcion inscripcionAspirante)
        {

            if (ModelState.IsValid) {

                var aspirante = new Aspirante
                {
                    TipoDocumento = inscripcionAspirante.Aspirante.TipoDocumento,
                    Documento = inscripcionAspirante.Aspirante.Documento,
                    Nombre = inscripcionAspirante.Aspirante.Nombre,
                    Apellido = inscripcionAspirante.Aspirante.Apellido,
                    FechaNacimiento = inscripcionAspirante.Aspirante.FechaNacimiento,
                    Direccion = inscripcionAspirante.Aspirante.Direccion,
                    Telefono = inscripcionAspirante.Aspirante.Telefono,
                    CorreoElectronico = inscripcionAspirante.Aspirante.CorreoElectronico,
                    Ciudad = inscripcionAspirante.Aspirante.Ciudad
                };

                var existeAspirante = await _context.Aspirantes
                                        .Where(a => a.CorreoElectronico == aspirante.CorreoElectronico || a.Documento == aspirante.Documento)
                                        .FirstOrDefaultAsync();

                if (existeAspirante != null)
                {
                    if (existeAspirante.CorreoElectronico == aspirante.CorreoElectronico)
                    {
                        ModelState.AddModelError("Aspirante.CorreoElectronico", "El correo electrónico ya está registrado.");
                    }
                    if (existeAspirante.Documento == aspirante.Documento)
                    {
                        ModelState.AddModelError("Aspirante.Documento", "El número de documento ya está registrado.");
                    }

                    await CargarDatosRegistro();
                    return View("Index", inscripcionAspirante);
                }

                _context.Aspirantes.Add(aspirante);
                await _context.SaveChangesAsync();

                var inscripcion = new Inscripcion
                {
                    AspiranteId = aspirante.Id,
                    TipoAspiranteId = inscripcionAspirante.TipoAspiranteId,
                    ProgramaId = inscripcionAspirante.ProgramaId,
                    FechaInscripcion = DateTime.Now
                };
                _context.Inscripciones.Add(inscripcion);
                await _context.SaveChangesAsync();

                return RedirectToAction("Inscripciones", "Informacion");
            }

            await CargarDatosRegistro();
            return View("Index", inscripcionAspirante);
        }
        private async Task CargarDatosRegistro()
        {
            ViewData["TiposDocumento"] = new SelectList(TiposDocumento.TDocumentos, "Nombre", "Nombre");
            ViewData["Ciudades"] = new SelectList(Ciudades.ListaCiudades, "Nombre", "Nombre");
            ViewData["Programas"] = new SelectList(await _context.Programas.ToListAsync(), "Id", "Nombre");
            ViewData["TiposAspirante"] = new SelectList(await _context.TiposAspirante.ToListAsync(), "Id", "Nombre");
        }
    }
}

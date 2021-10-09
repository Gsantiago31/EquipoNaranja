using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducacionEnCasa.Data;
using EducacionEnCasa.Models;
using EducacionEnCasa.ViewsModels;

namespace EducacionEnCasa
{
    public class AcudientesController : Controller
    {
        private readonly EducacionEnCasaContext _context;

        public AcudientesController(EducacionEnCasaContext context)
        {
            _context = context;
        }

        // GET: Acudientes
        public async Task<IActionResult> Index()
        {
            var sAcudientes = await(from A in _context.Acudientes
                               join E in _context.Estudiantes on A.idEstudiante equals E.Id
                               select new AcudientesViewsModels
                               {
                                   Id = A.id,
                                   Cedula_identidad =A.Cedula_identidad,
                                   Nombre = A.Nombre,
                                   Apellido = A.Apellido,
                                   Telefono=A.Telefono,
                                   Direccion=A.Direccion,
                                   idEstudiante = E.Id,
                                   NombreEstudiante=E.Nombre,
                                   ApellidoEstudiante=E.Apellido,
                                   TelefonoEstudiante=E.Telefono,
                                   DireccionEstudiante=E.Direccion
                               }).ToListAsync();
            ViewBag.sListAcudientes = sAcudientes;
            //return View(await _context.Acudientes.ToListAsync());
            return View();
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acudientes = await _context.Acudientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (acudientes == null)
            {
                return NotFound();
            }

            return View(acudientes);
        }

        // GET: Acudientes/Create
        public IActionResult Create()
        {
            ViewBag.Estudiantes = _context.Estudiantes.ToList();
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id, Cedula_identidad,Nombre,Apellido,Telefono,Direccion,idEstudiante")] Acudientes acudientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acudientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acudientes);
        }

        // GET: Acudientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Estudiantes = await _context.Estudiantes.ToListAsync();

            var acudientes = await _context.Acudientes.FindAsync(id);
            if (acudientes == null)
            {
                return NotFound();
            }
            return View(acudientes);
        }

        // POST: Acudientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Cedula_identidad,Nombre,Apellido,Telefono,Direccion,idEstudiante")] Acudientes acudientes)
        {
            if (id != acudientes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acudientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcudientesExists(acudientes.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(acudientes);
        }

        // GET: Acudientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acudientes = await _context.Acudientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (acudientes == null)
            {
                return NotFound();
            }

            return View(acudientes);
        }

        // POST: acudientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acudientes = await _context.Acudientes.FindAsync(id);
            _context.Acudientes.Remove(acudientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcudientesExists(int id)
        {
            return _context.Acudientes.Any(e => e.id == id);
        }
    }
}

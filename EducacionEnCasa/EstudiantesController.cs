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
    public class EstudiantesController : Controller
    {
        private readonly EducacionEnCasaContext _context;

        public EstudiantesController(EducacionEnCasaContext context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            var sEstudiantes = await (from E in _context.Estudiantes
                                      join D in _context.Docentes on E.Id_Docente equals D.Id
                                      join A in _context.Acudientes on E.Id_Acudiente equals A.Id
                                      select new EstudiantesViewsModels
                                      {
                                          Id = E.Id,
                                          Nombre = E.Nombre,
                                          Apellido = E.Apellido,
                                          Telefono = E.Telefono,
                                          Direccion = E.Direccion,
                                          Edad = E.Edad,
                                          Tarjeta_identidad = E.Tarjeta_identidad,
                                          Id_Docente = E.Id_Docente,
                                          NombresDocente = D.Nombre,
                                          ApellidosDocente = D.Apellido,
                                          TelefonoDocente = D.Telefono,
                                          DireccionDocente = D.Direccion,
                                          NivelEducativo = D.Nivel_educativo,
                                          CC = D.Cedula_identidad,
                                          Id_Acudiente = E.Id_Acudiente,
                                          NombreAcudiente = A.Nombre,
                                          ApellidoAcudiente = A.Apellido,
                                          TelefonoAcudiente = A.Telefono,
                                          DireccionAcudiente = A.Direccion,
                                          CC_Acudiente = A.Cedula_identidad
                                      }).ToListAsync();
            ViewBag.sListEstudiantes = sEstudiantes;
            return View();
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return View(estudiantes);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            ViewBag.Docentes = _context.Docentes.ToList();
            ViewBag.Acudientes = _context.Acudientes.ToList();

            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tarjeta_identidad,Nombre,Apellido,Edad,Telefono,Direccion,Id_Acudiente,Id_Docente")] Estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiantes);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Docentes = await _context.Docentes.ToListAsync();
            ViewBag.Acudientes = await _context.Acudientes.ToListAsync();

            var estudiantes = await _context.Estudiantes.FindAsync(id);
            if (estudiantes == null)
            {
                return NotFound();
            }
            return View(estudiantes);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tarjeta_identidad,Nombre,Apellido,Edad,Telefono,Direccion,Id_Acudiente,Id_Docente")] Estudiantes estudiantes)
        {
            if (id != estudiantes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiantesExists(estudiantes.Id))
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
            return View(estudiantes);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return View(estudiantes);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiantes = await _context.Estudiantes.FindAsync(id);
            _context.Estudiantes.Remove(estudiantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiantesExists(int id)
        {
            return _context.Estudiantes.Any(e => e.Id == id);
        }
    }
}

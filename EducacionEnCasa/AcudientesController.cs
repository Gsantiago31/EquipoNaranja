using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducacionEnCasa.Data;
using EducacionEnCasa.Models;

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
            return View(await _context.Acudientes.ToListAsync());
        }

        // GET: Acudientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acudientes = await _context.Acudientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acudientes == null)
            {
                return NotFound();
            }

            return View(acudientes);
        }

        // GET: Acudientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acudientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cedula_identidad,Nombre,Apellido,Telefono,Direccion")] Acudientes acudientes)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cedula_identidad,Nombre,Apellido,Telefono,Direccion")] Acudientes acudientes)
        {
            if (id != acudientes.Id)
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
                    if (!AcudientesExists(acudientes.Id))
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acudientes == null)
            {
                return NotFound();
            }

            return View(acudientes);
        }

        // POST: Acudientes/Delete/5
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
            return _context.Acudientes.Any(e => e.Id == id);
        }
    }
}

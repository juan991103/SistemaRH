using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaRH.Data;
using SistemaRH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRH.Controllers
{
    public class IdiomaController : Controller
    {
        private readonly DataContext _context;

        public IdiomaController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var idioma = _context.gestion_idiomas.ToList();
            return View(idioma);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Idioma idiomas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(idiomas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(idiomas);
        }

        // GET: Cargos/Delete/5 eliminar
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomas = await _context.gestion_idiomas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idiomas == null)
            {
                return NotFound();
            }

            return View(idiomas);
        }

        // POST: competencia/Delete/5 eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idiomas = await _context.gestion_idiomas.FindAsync(id);
            _context.gestion_idiomas.Remove(idiomas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //metodo get para editar
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomas = await _context.gestion_idiomas.FindAsync(id);
            if (idiomas == null)
            {
                return NotFound();
            }
            return View(idiomas);
        }

        //post de edicion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado")] Idioma idiomas)
        {
            if (id != idiomas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idiomas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdiomaExists(idiomas.Id))
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
            return View(idiomas);
        }

        private bool IdiomaExists(int id)
        {
            return _context.gestion_idiomas.Any(e => e.Id == id);
        }
    }
}

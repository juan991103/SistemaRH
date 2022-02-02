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
    public class CapacitacionController : Controller
    {
        private readonly DataContext _context;

        public CapacitacionController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var capacitacion = _context.gestion_capacitacion.ToList();
            return View(capacitacion);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Nivel,Fecha_Desde,Fecha_Hasta,Institucion")] Capacitacion capacitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capacitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(capacitacion);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencia = await _context.gestion_capacitacion.FindAsync(id);
            if (competencia == null)
            {
                return NotFound();
            }
            return View(competencia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Descripcion, Nivel, Fecha_Desde, Fecha_Hasta, Institucion")] Capacitacion capacitacion)
        {
            if (id != capacitacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capacitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapacitacionExists(capacitacion.Id))
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
            return View(capacitacion);
        }

        private bool CapacitacionExists(int id)
        {
            return _context.gestion_competencia.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capacitacion = await _context.gestion_capacitacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capacitacion == null)
            {
                return NotFound();
            }

            return View(capacitacion);
        }

        // POST: competencia/Delete/5 eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capacitacion = await _context.gestion_capacitacion.FindAsync(id);
            _context.gestion_capacitacion.Remove(capacitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

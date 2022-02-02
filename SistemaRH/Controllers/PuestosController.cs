using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaRH.Data;
using SistemaRH.Models;

namespace SistemaRH.Controllers
{
    public class PuestosController : Controller
    {
        private readonly DataContext _context;

        public PuestosController(DataContext context)
        {
            _context = context;
        }

        // GET: Puestos
        public async Task<IActionResult> Index()
        {
            return View(await _context.gestion_puestos.ToListAsync());
        }

        // GET: Puestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestos = await _context.gestion_puestos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestos == null)
            {
                return NotFound();
            }

            return View(puestos);
        }

        // GET: Puestos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Nivel_Riesgo,Minimo_Salario,Maximo_Salario,Estado")] Puestos puestos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puestos);
        }

        // GET: Puestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestos = await _context.gestion_puestos.FindAsync(id);
            if (puestos == null)
            {
                return NotFound();
            }
            return View(puestos);
        }

        // POST: Puestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Nivel_Riesgo,Minimo_Salario,Maximo_Salario,Estado")] Puestos puestos)
        {
            if (id != puestos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestosExists(puestos.Id))
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
            return View(puestos);
        }

        // GET: Puestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestos = await _context.gestion_puestos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestos == null)
            {
                return NotFound();
            }

            return View(puestos);
        }

        // POST: Puestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puestos = await _context.gestion_puestos.FindAsync(id);
            _context.gestion_puestos.Remove(puestos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestosExists(int id)
        {
            return _context.gestion_puestos.Any(e => e.Id == id);
        }
    }
}

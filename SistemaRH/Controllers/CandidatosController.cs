using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
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
    public class CandidatosController : Controller
    {
        private readonly DataContext _context;
        
        public CandidatosController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.gestion_candidatos.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string busqueda)
        {
            var nombres = from s in _context.gestion_candidatos
                          select s;
            if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Nombre.Contains(busqueda) 
                || s.Departamento.Contains(busqueda) || s.Competencias.Contains(busqueda) 
                || s.Capacitacion.Contains(busqueda) || s.Puesto.Contains(busqueda)
                || s.Experiencia_laboral.Equals(busqueda) || s.Idioma_dominante.Contains(busqueda));
            }
            else if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Competencias.Contains(busqueda));
            }

            return View(await nombres.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Invi()
        {
            return View(await _context.gestion_candidatos.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Invi(string busqueda)
        {
            var nombres = from s in _context.gestion_candidatos
                          select s;
            if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Nombre.Contains(busqueda)
                || s.Departamento.Contains(busqueda) || s.Competencias.Contains(busqueda)
                || s.Capacitacion.Contains(busqueda) || s.Puesto.Contains(busqueda)
                || s.Experiencia_laboral.Equals(busqueda) || s.Idioma_dominante.Contains(busqueda));
            }
            else if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Competencias.Contains(busqueda));
            }

            return View(await nombres.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Completa()
        {
            return View(await _context.gestion_candidatos.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Completa(string busqueda)
        {
            var nombres = from s in _context.gestion_candidatos
                          select s;
            if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Nombre.Contains(busqueda)
                || s.Departamento.Contains(busqueda) || s.Competencias.Contains(busqueda)
                || s.Capacitacion.Contains(busqueda) || s.Puesto.Contains(busqueda)
                || s.Experiencia_laboral.Equals(busqueda) || s.Idioma_dominante.Contains(busqueda));
            }
            else if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Competencias.Contains(busqueda));
            }

            return View(await nombres.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Completa2()
        {
            return View(await _context.gestion_candidatos.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Completa2(string busqueda)
        {
            var nombres = from s in _context.gestion_candidatos
                          select s;
            if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Nombre.Contains(busqueda)
                || s.Departamento.Contains(busqueda) || s.Competencias.Contains(busqueda)
                || s.Capacitacion.Contains(busqueda) || s.Puesto.Contains(busqueda)
                || s.Experiencia_laboral.Equals(busqueda) || s.Idioma_dominante.Contains(busqueda));
            }
            else if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Competencias.Contains(busqueda));
            }

            return View(await nombres.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.gestion_candidatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            //obtener datos de puestos
            List<string> puestos = new List<string>();
            var vd = from em in _context.gestion_puestos where (em.Estado == true) select em;
            foreach (var item in vd)
            {
                puestos.Add(item.Nombre);
                ViewBag.puest = puestos;
            }

            //obtener datos de departamento
            List<string> departamento = new List<string>();
            var ve = _context.gestion_departamento.ToList();
            foreach (var item in ve)
            {
                departamento.Add(item.Nombre);
                ViewBag.dep = departamento;
            }

            //obtener datos de competencia
            List<string> competencia = new List<string>();
            var vc = from em in _context.gestion_competencia where (em.Estado == true) select em;
            foreach (var item in vc)
            {
                competencia.Add(item.Descripcion);
                ViewBag.comp = competencia;
            }

            //obtener datos de capacitacion
            List<string> capacitacion = new List<string>();
            var vt = _context.gestion_capacitacion.ToList();
            foreach (var item in vt)
            {
                capacitacion.Add(item.Descripcion);
                ViewBag.capa = capacitacion;
            }

            //obtener datos de idiomas
            List<string> idiomas = new List<string>();
            var vi = from em in _context.gestion_idiomas where (em.Estado == true) select em;
            foreach (var item in vi)
            {
                idiomas.Add(item.Nombre);
                ViewBag.idi = idiomas;
                ViewBag.idi2 = idiomas;
            }

            return View();
        }

        // POST: Candidatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cedula,Nombre,Puesto,Departamento,Salario,Competencias,Capacitacion,Experiencia_laboral,Idioma_dominante,Idioma_secundario,Recomendacion,Estado")] Candidatos candidatos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidatos);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //obtener datos de puestos
            List<string> puestos = new List<string>();
            var vd = from em in _context.gestion_puestos where (em.Estado == true) select em;
            foreach (var item in vd)
            {
                puestos.Add(item.Nombre);
                ViewBag.puest = puestos;
            }

            //obtener datos de departamento
            List<string> departamento = new List<string>();
            var ve = _context.gestion_departamento.ToList();
            foreach (var item in ve)
            {
                departamento.Add(item.Nombre);
                ViewBag.dep = departamento;
            }

            //obtener datos de competencia
            List<string> competencia = new List<string>();
            var vc = from em in _context.gestion_competencia where (em.Estado == true) select em;
            foreach (var item in vc)
            {
                competencia.Add(item.Descripcion);
                ViewBag.comp = competencia;
            }

            //obtener datos de capacitacion
            List<string> capacitacion = new List<string>();
            var vt = _context.gestion_capacitacion.ToList();
            foreach (var item in vt)
            {
                capacitacion.Add(item.Descripcion);
                ViewBag.capa = capacitacion;
            }

            //obtener datos de idiomas
            List<string> idiomas = new List<string>();
            var vi = from em in _context.gestion_idiomas where (em.Estado == true) select em;
            
            foreach (var item in vi)
            {
                idiomas.Add(item.Nombre);
                ViewBag.idi = idiomas;
                ViewBag.idi2 = idiomas;
            }

            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.gestion_candidatos.FindAsync(id);
            if (candidatos == null)
            {
                return NotFound();
            }
            return View(candidatos);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cedula,Nombre,Puesto,Departamento,Salario,Competencias,Capacitacion,Experiencia_laboral,Idioma_dominante,Idioma_secundario,Recomendacion,Estado")] Candidatos candidatos)
        {
            if (id != candidatos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatosExists(candidatos.Id))
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
            return View(candidatos);
        }

        // GET: Candidatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatos = await _context.gestion_candidatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatos == null)
            {
                return NotFound();
            }

            return View(candidatos);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatos = await _context.gestion_candidatos.FindAsync(id);
            _context.gestion_candidatos.Remove(candidatos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatosExists(int id)
        {
            return _context.gestion_candidatos.Any(e => e.Id == id);
        }
    }
}

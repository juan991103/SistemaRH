using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SistemaRH.Data;
using SistemaRH.Models;
using System.Text;

namespace SistemaRH.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment env;

        public EmpleadosController(DataContext context, IWebHostEnvironment host)
        {
            _context = context;
            env = host;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string busqueda, string fecha, DateTime start, DateTime end)
        {
            var nombres = from s in _context.empleados
                          select s;
                        
            if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Nombre.Contains(busqueda) && s.Departamento.Contains(busqueda) && s.Puesto.Contains(busqueda));
            }
            else
            {
                nombres = nombres.Where(s => s.Fecha_Ingreso >= start && s.Fecha_Ingreso <= end);

            }
            
            return View(await nombres.AsNoTracking().ToListAsync());
        }        

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.empleados.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index2(string busqueda, string fecha, DateTime start, DateTime end)
        {
            var nombres = from s in _context.empleados
                          select s;
            if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Nombre.Contains(busqueda) || s.Departamento.Contains(busqueda) || s.Puesto.Contains(busqueda));
            }
            else
            {
                nombres = nombres.Where(s => s.Fecha_Ingreso >= start && s.Fecha_Ingreso <= end);

            }
            return View(await nombres.AsNoTracking().ToListAsync());
        }

        // GET: Empleados
        public async Task<IActionResult> Index2()
        {
            return View(await _context.empleados.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index3(string busqueda, string fecha, DateTime start, DateTime end)
        {
            var nombres = from s in _context.empleados
                          select s;
            if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Nombre.Contains(busqueda) || s.Departamento.Contains(busqueda) || s.Puesto.Contains(busqueda));
            }
            else
            {
                nombres = nombres.Where(s => s.Fecha_Ingreso >= start && s.Fecha_Ingreso <= end);

            }
            return View(await nombres.AsNoTracking().ToListAsync());
        }

        // GET: Empleados
        public async Task<IActionResult> Index3()
        {
            return View(await _context.empleados.ToListAsync());
        }

        [HttpPost]
        [System.Web.Mvc.ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            return File(Encoding.ASCII.GetBytes(GridHtml), "application/vnd.ms-excel", "Grid.xls");
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.empleados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            //obtener datos de candidatos
            List<string> empleado = new List<string>();
            var vd = from em in _context.gestion_candidatos where (em.Estado == true) select em;
            foreach (var item in vd)
            {
                empleado.Add(item.Nombre);
                ViewBag.emps = empleado;
            }

            //obtener datos de puestos
            List<string> puestos = new List<string>();
            var vp = from em in _context.gestion_puestos where (em.Estado == true) select em;
            foreach (var item in vp)
            {
                puestos.Add(item.Nombre);
                ViewBag.pst = puestos;
            }

            //obtener datos de departamento
            List<string> departamento = new List<string>();
            var ve = _context.gestion_departamento.ToList();
            foreach (var item in ve)
            {
                departamento.Add(item.Nombre);
                ViewBag.dep = departamento;
            }

            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cedula,Nombre,Fecha_Ingreso,Departamento,Puesto,Salario_Mensual,Estado")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //obtener datos de puestos
            List<string> empleado = new List<string>();
            var vd = from em in _context.gestion_candidatos where (em.Estado == true) select em;
            foreach (var item in vd)
            {
                empleado.Add(item.Nombre);
                ViewBag.emps = empleado;
            }

            //obtener datos de puestos
            List<string> puestos = new List<string>();
            var vp = from em in _context.gestion_puestos where (em.Estado == true) select em;
            foreach (var item in vp)
            {
                puestos.Add(item.Nombre);
                ViewBag.pst = puestos;
            }

            //obtener datos de departamento
            List<string> departamento = new List<string>();
            var ve = _context.gestion_departamento.ToList();
            foreach (var item in ve)
            {
                departamento.Add(item.Nombre);
                ViewBag.dep = departamento;
            }

            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cedula,Nombre,Fecha_Ingreso,Departamento,Puesto,Salario_Mensual,Estado")] Empleados empleados)
        {
            if (id != empleados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.Id))
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
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.empleados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleados = await _context.empleados.FindAsync(id);
            _context.empleados.Remove(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
            return _context.empleados.Any(e => e.Id == id);
        }
        
        public ActionResult Imprimir()
        {
            return RedirectToAction("Index");
        }

    }
}

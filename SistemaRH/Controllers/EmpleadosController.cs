using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SistemaRH.Data;
using SistemaRH.Models;

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
                
        [HttpGet]
        [Route("ExportEmpleado")]
        public string Imprimir()
        {
            string rootFolder = env.WebRootPath;
            string fileName = @"ExportCustomers.xlsx";

            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {

                IList<Empleados> customerList = _context.empleados.ToList();

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Empleado");
                int totalRows = customerList.Count();

                worksheet.Cells[1, 2].Value = "Cedula";
                worksheet.Cells[1, 3].Value = "Nombre";
                worksheet.Cells[1, 4].Value = "Fecha_Ingreso";
                worksheet.Cells[1, 5].Value = "Departamento";
                worksheet.Cells[1, 6].Value = "Puesto";
                worksheet.Cells[1, 7].Value = "Salario_Mensual";
                int i = 0;
                for (int row = 2; row <= totalRows + 1; row++)
                {
                    worksheet.Cells[row, 2].Value = customerList[i].Cedula;
                    worksheet.Cells[row, 3].Value = customerList[i].Nombre;
                    worksheet.Cells[row, 4].Value = customerList[i].Fecha_Ingreso;
                    worksheet.Cells[row, 5].Value = customerList[i].Departamento;
                    worksheet.Cells[row, 6].Value = customerList[i].Puesto;
                    worksheet.Cells[row, 7].Value = customerList[i].Salario_Mensual;
                    i++;
                }

                package.Save();

            }

            return " Customer list has been exported successfully";
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaRH.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRH.Controllers
{
    public class ExampleController : Controller
    {
        private readonly DataContext _context;

        public ExampleController(DataContext context)
        {
            _context = context;
        }
            // GET: ExampleController
        public ActionResult Index(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                if (DateTime.TryParse(search, out var dateTime))
                {
                    var empleado = _context.empleados.Where(x => x.Fecha_Ingreso.ToShortDateString() == dateTime.ToShortDateString()).ToList();
                }
            }

            return View(_context);
        }

        // GET: ExampleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExampleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExampleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExampleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExampleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExampleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExampleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

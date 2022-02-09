using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRH.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment host;
        public ReportController(IWebHostEnvironment hostweb) 
        {
            this.host = hostweb;
        }
        public IActionResult Index()
        {
            return View();
        }

        
    }
}

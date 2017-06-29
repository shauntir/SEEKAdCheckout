using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEEKAdCheckout.Domain.DB;
using SEEKAdCheckout.Domain.Entities;

namespace SEEKAdCheckout.Web.Controllers
{
    public class DefaultController : Controller
    {
        private readonly SEEKAdContext _context;

        public DefaultController(SEEKAdContext context)
        {
            _context = context;    
        }

        // GET: default
        public async Task<IActionResult> Index()
        {
            return Content("FOO");
            //return View(await _context.Checkouts.ToListAsync());
        }
    }
}

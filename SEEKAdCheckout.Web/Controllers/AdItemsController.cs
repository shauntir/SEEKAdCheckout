using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEEKAdCheckout.Domain.DB;
using SEEKAdCheckout.Domain.Entities;

namespace SEEKAdCheckout.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/AdItems")]
    public class AdItemsController : Controller
    {
        private readonly SEEKAdContext _context;

        public AdItemsController(SEEKAdContext context)
        {
            _context = context;
        }

        // GET: api/AdItems
        [HttpGet]
        public IEnumerable<AdItem> GetAdItems()
        {
            return _context.AdItems;
        }

        // GET: api/AdItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdItem([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adItem = await _context.AdItems.SingleOrDefaultAsync(m => m.Id == id);

            if (adItem == null)
            {
                return NotFound();
            }

            return Ok(adItem);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetFlox.DAL;

namespace NetFlox.Controllers
{
    public class CelebritesController : Controller
    {
        private readonly NetFloxEntities _context;

        public CelebritesController(NetFloxEntities context)
        {
            _context = context;
        }

        // GET: Celebrites
        public async Task<IActionResult> Index()
        {
            var celebrites = await _context.Celebrites
                .OrderBy(c => c.Nom)
                .ToListAsync();
            return View(celebrites);
        }

        public async Task<IActionResult> Search(string search)
        {
            if (search == null)
            {
                return NotFound();
            }

            ViewBag.search = search;


            var celebrites = await _context.Celebrites
                    .Where(c => EF.Functions.Like(c.Nom, "%" + search + "%"))
                    .OrderByDescending(c => c.Nom)
                    .ToListAsync();
            if (celebrites == null)
            {
                return NotFound();
            }

            return View(celebrites);
        }

        // GET: Celebrites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celebrite = await _context.Celebrites
                .Include(c => c.RoleCelebriteFilms)
                .ThenInclude(rcf => rcf.Role)
                .Include(c => c.RoleCelebriteFilms)
                .ThenInclude(rcf => rcf.Film)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celebrite == null)
            {
                return NotFound();
            }

            return View(celebrite);
        }
    }
}

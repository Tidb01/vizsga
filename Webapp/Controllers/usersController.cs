using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EZAZ.Data;
using EZAZ.Models;
using Microsoft.AspNetCore.Authorization;

namespace EZAZ.Controllers
{
    public class usersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public usersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: users
        public async Task<IActionResult> Index()
        {
            return View(await _context.users.ToListAsync());
        }

        // Submit: users/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        //Submit: users/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index", await _context.users.Where(j => j.username.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }
        
        

        private bool usersExists(int id)
        {
            return _context.users.Any(e => e.ID == id);
        }
    }
}

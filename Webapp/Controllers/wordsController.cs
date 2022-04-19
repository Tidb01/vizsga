using EZAZ.Data;
using EZAZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EZAZ.Controllers
{
    public class wordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public wordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: words
        public async Task<IActionResult> Index()
        {
            return View(await _context.words.ToListAsync());
        }

        //GET: words/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        //Submit: words/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index",await _context.words.Where (j => j.word.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: words/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var words = await _context.words
                .FirstOrDefaultAsync(m => m.ID == id);
            if (words == null)
            {
                return NotFound();
            }

            return View(words);
        }

        // GET: words/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: words/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,word,score")] words words)
        {
            if (ModelState.IsValid)
            {
                _context.Add(words);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(words);
        }

        // GET: words/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var words = await _context.words.FindAsync(id);
            if (words == null)
            {
                return NotFound();
            }
            return View(words);
        }

        // POST: words/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,word,score")] words words)
        {
            if (id != words.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(words);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!wordsExists(words.ID))
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
            return View(words);
        }

        // GET: words/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var words = await _context.words
                .FirstOrDefaultAsync(m => m.ID == id);
            if (words == null)
            {
                return NotFound();
            }

            return View(words);
        }

        // POST: words/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var words = await _context.words.FindAsync(id);
            _context.words.Remove(words);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool wordsExists(int id)
        {
            return _context.words.Any(e => e.ID == id);
        }
    }
}

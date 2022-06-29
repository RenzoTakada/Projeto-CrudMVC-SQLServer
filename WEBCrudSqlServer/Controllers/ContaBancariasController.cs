using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBCrudSqlServer.Models;

namespace WEBCrudSqlServer.Controllers
{
    public class ContaBancariasController : Controller
    {
        private readonly Context _context;

        public ContaBancariasController(Context context)
        {
            _context = context;
        }

        // GET: ContaBancarias
        public async Task<IActionResult> Index()
        {
              return _context.ContaBancaria != null ? 
                          View(await _context.ContaBancaria.ToListAsync()) :
                          Problem("Entity set 'Context.ContaBancaria'  is null.");
        }

        // GET: ContaBancarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContaBancaria == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContaBancaria
                .FirstOrDefaultAsync(m => m.NumeroDaConta == id);
            if (contaBancaria == null)
            {
                return NotFound();
            }

            return View(contaBancaria);
        }

        // GET: ContaBancarias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContaBancarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Agencia,NumeroDaConta")] ContaBancaria contaBancaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contaBancaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contaBancaria);
        }

        // GET: ContaBancarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContaBancaria == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContaBancaria.FindAsync(id);
            if (contaBancaria == null)
            {
                return NotFound();
            }
            return View(contaBancaria);
        }

        // POST: ContaBancarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Agencia,NumeroDaConta")] ContaBancaria contaBancaria)
        {
            if (id != contaBancaria.NumeroDaConta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contaBancaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaBancariaExists(contaBancaria.NumeroDaConta))
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
            return View(contaBancaria);
        }

        // GET: ContaBancarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContaBancaria == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContaBancaria
                .FirstOrDefaultAsync(m => m.NumeroDaConta == id);
            if (contaBancaria == null)
            {
                return NotFound();
            }

            return View(contaBancaria);
        }

        // POST: ContaBancarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContaBancaria == null)
            {
                return Problem("Entity set 'Context.ContaBancaria'  is null.");
            }
            var contaBancaria = await _context.ContaBancaria.FindAsync(id);
            if (contaBancaria != null)
            {
                _context.ContaBancaria.Remove(contaBancaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaBancariaExists(int id)
        {
          return (_context.ContaBancaria?.Any(e => e.NumeroDaConta == id)).GetValueOrDefault();
        }
    }
}

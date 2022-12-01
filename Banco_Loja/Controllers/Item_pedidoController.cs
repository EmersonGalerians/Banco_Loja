using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Banco.EF;
using Banco_Loja.Data;

namespace Banco_Loja.Controllers
{
    public class Item_pedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Item_pedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Item_pedido
        public async Task<IActionResult> Index()
        {
            return View(await _context.Item_pedido.ToListAsync());
        }

        // GET: Item_pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_pedido = await _context.Item_pedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item_pedido == null)
            {
                return NotFound();
            }

            return View(item_pedido);
        }

        // GET: Item_pedido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Item_pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,Valor_Total,Produto_Id,Pedidido_Id")] Item_pedido item_pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item_pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item_pedido);
        }

        // GET: Item_pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_pedido = await _context.Item_pedido.FindAsync(id);
            if (item_pedido == null)
            {
                return NotFound();
            }
            return View(item_pedido);
        }

        // POST: Item_pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantidade,Valor_Total,Produto_Id,Pedidido_Id")] Item_pedido item_pedido)
        {
            if (id != item_pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item_pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Item_pedidoExists(item_pedido.Id))
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
            return View(item_pedido);
        }

        // GET: Item_pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item_pedido = await _context.Item_pedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item_pedido == null)
            {
                return NotFound();
            }

            return View(item_pedido);
        }

        // POST: Item_pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item_pedido = await _context.Item_pedido.FindAsync(id);
            _context.Item_pedido.Remove(item_pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Item_pedidoExists(int id)
        {
            return _context.Item_pedido.Any(e => e.Id == id);
        }
    }
}

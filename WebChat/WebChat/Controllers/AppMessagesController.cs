using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebChat.Etities;

namespace WebChat.Controllers
{
    public class AppMessagesController : Controller
    {
        private readonly ChattingAppDbContext _context;

        public AppMessagesController(ChattingAppDbContext context)
        {
            _context = context;
        }

        // GET: AppMessages
        public async Task<IActionResult> Index()
        {
              return _context.AppMessages != null ? 
                          View(await _context.AppMessages.ToListAsync()) :
                          Problem("Entity set 'ChattingAppDbContext.AppMessages'  is null.");
        }

        // GET: AppMessages/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.AppMessages == null)
            {
                return NotFound();
            }

            var appMessage = await _context.AppMessages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appMessage == null)
            {
                return NotFound();
            }

            return View(appMessage);
        }

        // GET: AppMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Sender,ConversationId,HasAttachment,SendAt")] AppMessage appMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appMessage);
        }

        // GET: AppMessages/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.AppMessages == null)
            {
                return NotFound();
            }

            var appMessage = await _context.AppMessages.FindAsync(id);
            if (appMessage == null)
            {
                return NotFound();
            }
            return View(appMessage);
        }

        // POST: AppMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Content,Sender,ConversationId,HasAttachment,SendAt")] AppMessage appMessage)
        {
            if (id != appMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppMessageExists(appMessage.Id))
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
            return View(appMessage);
        }

        // GET: AppMessages/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.AppMessages == null)
            {
                return NotFound();
            }

            var appMessage = await _context.AppMessages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appMessage == null)
            {
                return NotFound();
            }

            return View(appMessage);
        }

        // POST: AppMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.AppMessages == null)
            {
                return Problem("Entity set 'ChattingAppDbContext.AppMessages'  is null.");
            }
            var appMessage = await _context.AppMessages.FindAsync(id);
            if (appMessage != null)
            {
                _context.AppMessages.Remove(appMessage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppMessageExists(long id)
        {
          return (_context.AppMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

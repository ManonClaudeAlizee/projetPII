using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetPII.Data;
using projetPII.Models;

namespace projetPII.Controllers;

public class EventController : Controller
{
    private readonly projetPIIContext _context;

    public EventController(projetPIIContext context)
    {
        _context = context;
    }

    // GET: Event
    public async Task<IActionResult> Index()
    {
        var events = await _context.Events
            // .Include(c => c.Department)
            // .OrderBy(c => c.Id)
            .ToListAsync();

        return View(events);
    }

    public IActionResult Create()
    {
        return View();
    }

    // POST: Event/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Date,DescriptionCourte,DescriptionLongue,Lieu")] Event ev)
    {
        //validation rules
        if (ModelState.IsValid)
        {
            // Create new event in DB
            _context.Add(ev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //redisplay form if failure
        return View(ev);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ev = await _context.Events
            .FirstOrDefaultAsync(m => m.Id == id);
        if (ev == null)
        {
            return NotFound();
        }

        return View(ev);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var ev = await _context.Events.FindAsync(id);
        _context.Events.Remove(ev!);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ev = await _context.Events.FindAsync(id);
        if (ev == null)
        {
            return NotFound();
        }
        return View(ev);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,DescriptionCourte,DescriptionLongue,Lieu")] Event ev)
    {
        if (id != ev.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ev);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(ev.Id))
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
        return View(ev);
    }

    private bool EventExists(int id)
    {
        return _context.Events.Any(e => e.Id == id);
    }
}

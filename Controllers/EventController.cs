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
    public async Task<IActionResult> Create([Bind("Id,Title,Date,Description,Lieu")] Event ev)
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
}

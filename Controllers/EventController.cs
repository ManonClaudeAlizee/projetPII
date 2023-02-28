using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetPII.Data;

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
}

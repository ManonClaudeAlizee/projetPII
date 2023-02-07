using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetPII.Data;
using projetPII.Models;

namespace projetPII.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserApiController : ControllerBase
{
    private readonly projetPIIContext _context;

    public UserApiController(projetPIIContext context)
    {
        _context = context;
    }

    // GET: api/UserApi
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        // Get users
        var users = _context.Users;
        // .OrderBy(s => s.LastName)
        // .ThenBy(s => s.FirstName);

        return await users.ToListAsync();
    }

    // GET: api/UserApi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        // Find student and related enrollments
        // SingleAsync() throws an exception if no student is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var user = await _context.Users
            // .Where(s => s.Id == id)
            // .Include(s => s.Enrollments)
            .SingleOrDefaultAsync();

        if (user == null)
            return NotFound();

        return user;
    }

    // POST: api/UserApi
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // DELETE: api/UserApi/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return NotFound();

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

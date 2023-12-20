using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace docker_postgres.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly UserContext _context;

  public UsersController(UserContext context)
  {
    _context = context;
  }

  // Get: api/users
  [HttpGet]
  public async Task<ActionResult<IEnumerable<User>>> GetUsers()
  {
    return await _context.Users.ToListAsync();
  }

  // Get: api/users/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<User>> GetUser(int id)
  {
    var user = await _context.Users.FindAsync(id);

    if (user == null)
    {
      return NotFound();
    }

    return user;
  }

  // Post: api/users
  [HttpPost]
  // public string PostUser()
  // {
  //   return "Post method";
  // }
  public async Task<ActionResult<User>> PostUser(User newUser)
  {
    _context.Users.Add(newUser);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
  }

  // PUT: api/users/{id}
  [HttpPut("{id}")]
  public async Task<IActionResult> PutUser(int id, User user)
  {
    if (id != user.Id)
    {
      return BadRequest();
    }

    _context.Entry(user).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    return NoContent();
  }

  // DELETE: api/users/{id}
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteUser(int id)
  {
    var user = await _context.Users.FindAsync(id);

    if (user == null)
    {
      return NotFound();
    }

    _context.Users.Remove(user);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  // Dummy endpoint to test the database connection
  [HttpGet("test")]
  public string Test()
  {
    return "Hello world!";
  }
}
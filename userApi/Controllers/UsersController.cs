using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using userApi.Data;
using userApi.Model;
using static System.Net.Mime.MediaTypeNames;

namespace userApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserApiDbContext _dbContext;

        public UsersController(UserApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get : api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            if (_dbContext.Users == null)
                return NotFound();

            return await _dbContext.Users.ToListAsync();
        }

        //Get : api/Users/2
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_dbContext.Users == null)
                return NotFound();

            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            return user;
        }

        //Get : api/Users/2
        [HttpGet("/Search/{text}")]
        public async Task<ActionResult<IEnumerable<User>>> Search(string text)
        {
            var matchedUsers = _dbContext.Users.Where(u => u.Name.Contains(text)).ToList();
            if (matchedUsers.Count == 0)
            {
                return NotFound(); // Return 404 if no users match the search text
            }
            return matchedUsers;
        }


        //Post : api/Users
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            _dbContext.Users.Add(user); 
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
        }

        //Put : api/Users/2
        [HttpPut]
        public async Task<ActionResult> UpdateUser(int id, User user)
        {
            if(id != user.Id)
                return BadRequest();

            _dbContext.Entry(user).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();    
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }


        //Delete : api/Users/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_dbContext.Users == null)
                return NotFound();

            var user = await _dbContext.Users.FindAsync(id);

            if(user == null)
                return NotFound();

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


        private bool UserExists(long id)
        {
            return (_dbContext.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}

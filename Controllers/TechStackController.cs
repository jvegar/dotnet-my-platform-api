using Microsoft.AspNetCore.Mvc;
using dotnet_my_platform_api.Data;
using dotnet_my_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_my_platform_api.Controllers
{
    [Route("api/tech-stack")]
    [ApiController]
    public class TechStackController : ControllerBase
    {
        private readonly MyPlatformContext _context;

        public TechStackController(MyPlatformContext context)
        {
            _context = context;
        }

        // GET: api/TechStack
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechStack>>> GetTechStacks()
        {
            return await _context.TechStacks.ToListAsync();
        }

        // GET: api/TechStack/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TechStack>> GetTechStack(int id)
        {
            var techStack = await _context.TechStacks.FindAsync(id);

            if (techStack == null)
            {
                return NotFound();
            }

            return techStack;
        }

        // POST: api/TechStack
        [HttpPost]
        public async Task<ActionResult<TechStack>> PostTechStack(TechStack techStack)
        {
            _context.TechStacks.Add(techStack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechStack", new { id = techStack.Id }, techStack);
        }

        // PUT: api/TechStack/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechStack(int id, TechStack techStack)
        {
            if (id != techStack.Id)
            {
                return BadRequest();
            }

            _context.Entry(techStack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechStackExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/TechStack/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechStack(int id)
        {
            var techStack = await _context.TechStacks.FindAsync(id);
            if (techStack == null)
            {
                return NotFound();
            }

            _context.TechStacks.Remove(techStack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechStackExists(int id)
        {
            return _context.TechStacks.Any(e => e.Id == id);
        }
    }
}
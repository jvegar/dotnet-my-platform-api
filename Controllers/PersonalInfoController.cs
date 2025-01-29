using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_my_platform_api.Data;
using dotnet_my_platform_api.Models;

namespace dotnet_my_platform_api.Controllers
{
    [Route("api/personal-info")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly MyPlatformContext _context;

        public PersonalInfoController(MyPlatformContext context)
        {
            _context = context;
        }

        // GET: api/personalinfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalInfo>>> GetPersonalInfos()
        {
            return await _context.PersonalInfos.ToListAsync();
        }

        // GET: api/personalinfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalInfo>> GetPersonalInfo(int id)
        {
            var personalInfo = await _context.PersonalInfos.FindAsync(id);

            if (personalInfo == null)
            {
                return NotFound();
            }

            return personalInfo;
        }

        // POST: api/personalinfo
        [HttpPost]
        public async Task<ActionResult<PersonalInfo>> PostPersonalInfo(PersonalInfo personalInfo)
        {
            _context.PersonalInfos.Add(personalInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonalInfo), new { id = personalInfo.Id }, personalInfo);
        }

        // PUT: api/personalinfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalInfo(int id, PersonalInfo personalInfo)
        {
            if (id != personalInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInfoExists(id))
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

        // DELETE: api/personalinfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalInfo(int id)
        {
            var personalInfo = await _context.PersonalInfos.FindAsync(id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            _context.PersonalInfos.Remove(personalInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalInfoExists(int id)
        {
            return _context.PersonalInfos.Any(e => e.Id == id);
        }
    }
}
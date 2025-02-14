using Microsoft.AspNetCore.Mvc;
using dotnet_my_platform_api.Data;
using dotnet_my_platform_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_my_platform_api.Controllers
{
    [Route("api/github-repos")]
    [ApiController]
    public class GitHubRepoController : ControllerBase
    {
        private readonly MyPlatformContext _context;

        public GitHubRepoController(MyPlatformContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GitHubRepo>>> GetGitHubRepos()
        {
            return await _context.GitHubRepos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GitHubRepo>> GetGitHubRepo(int id)
        {
            var gitHubRepo = await _context.GitHubRepos.FindAsync(id);
            if (gitHubRepo == null)
            {
                return NotFound();
            }
            return gitHubRepo;
        }

        [HttpPost]
        public async Task<ActionResult<GitHubRepo>> PostGitHubRepo(GitHubRepo gitHubRepo)
        {
            _context.GitHubRepos.Add(gitHubRepo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGitHubRepo), new { id = gitHubRepo.Id }, gitHubRepo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGitHubRepo(int id, GitHubRepo gitHubRepo)
        {
            if (id != gitHubRepo.Id)
            {
                return BadRequest();
            }
            _context.Entry(gitHubRepo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGitHubRepo(int id)
        {
            var gitHubRepo = await _context.GitHubRepos.FindAsync(id);
            if (gitHubRepo == null)
            {
                return NotFound();
            }
            _context.GitHubRepos.Remove(gitHubRepo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 
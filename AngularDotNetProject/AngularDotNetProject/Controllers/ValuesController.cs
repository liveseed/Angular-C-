using System.Threading.Tasks;
using AngularDotNetProject.Repository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AngularDotNetProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventsAsync()
        {
            try
            {
                var result = await _context.Events.ToListAsync();

                return Ok(result);  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Consult failed");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEventByIdAsync(int id)
        {
            try
            {
                var result = await _context.Events.FirstOrDefaultAsync(x => x.EventId == id);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Consult failed");
            }
}
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApp.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraiController : ControllerBase
    {
        private readonly SamuraiContext samuraiContext;

        public SamuraiController(SamuraiContext samuraiContext)
        {
            this.samuraiContext = samuraiContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Samurai>>> GetSamurais()
        {
            return await samuraiContext.Samurais.ToListAsync();
        }
    }
}

using EF6SQLWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF6SQLWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RpgCharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public RpgCharacterController(DataContext context) 
        { 
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<RpgCharacter>>> AddCharacter(RpgCharacter character)
        {
            _context.RpgCharacters.Add(character);
            await _context.SaveChangesAsync();

            return Ok(await _context.RpgCharacters.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<RpgCharacter>>> GetAllCharacters(RpgCharacter character)
        {
            return Ok(await _context.RpgCharacters.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RpgCharacter>> GetCharacter(int id)
        {
            var character = await _context.RpgCharacters.FindAsync(id);
            if(character == null)
            {
                return BadRequest("Character not found");
            }
            return Ok(character);
        }
    }
}

using AutoMapper;
using Marvelous.Data;
using Marvelous.Models;
using Marvelous.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Marvelous.Controllers
{
    // Create a controller call it Mason
    // GetAllVillas()  GET / api / villa  200 OK + list of DTOs	Returns all villas
    // GetVillaById(id)	GET /api/villa/7	200 OK or 404 NotFound	Returns one villa
    // CreateVilla()	POST /api/villa	201 Created + new DTO Creates new villa
    // Return proper error messages and status codes
    // Use AutoMapper for mapping between entities and DTOs
    // Use Entity Framework Core for data access
    // Use dependency injection for DbContext and AutoMapper

    [Route("API/[controller]")]
    [ApiController]
    public class MasonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MasonController(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Get All Mason")]
        public ActionResult<IEnumerable<Villa>> GetAllVillas()
        {
            var villas = _context.Villas.ToList();

            if (villas == null || villas.Count == 0)
            {
                return NotFound("No villas found.");
            }

            var villaDtos = _mapper.Map<List<VillaDTO>>(villas);

            return Ok(villaDtos);
        }

        [HttpGet("id:int:min{id}")]
        public ActionResult<VillaDTO> GetVillaById(int id)
        {
            var vialla = _context.Villas.FirstOrDefault(v => v.Id == id);

            if (vialla == null)
            {
                return NotFound($"Villa with id {id} not found.");
            }

            var villaDto = _mapper.Map<VillaDTO>(vialla);

            return Ok(villaDto);
        }

        [HttpPost("Create My Villa")]
        public ActionResult CreateVilla(VillaDTO villaDto)
        {
            if (villaDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myVilla = _mapper.Map<Villa>(villaDto);
            myVilla.CreatedDate = DateTime.Now;
            myVilla.UpdatedDate = DateTime.Now;

            _context.Villas.Add(myVilla);
            _context.SaveChanges();
            var createVilaaDto = _mapper.Map<VillaDTO>(myVilla);

            return CreatedAtAction(nameof(GetVillaById), new { id = myVilla.Id }, createVilaaDto);
        }

        [HttpDelete]
        public ActionResult DeleteVilla(int id)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound($"Villa with id {id} not found.");
            }

            _context.Villas.Remove(villa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

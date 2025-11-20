using AutoMapper;
using Marvelous.Data;
using Marvelous.Models;
using Marvelous.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Marvelous.Controllers
{
    [Route("Villa/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public HomeController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetAllVillas")]
        public ActionResult<IEnumerable<Villa>> GetAllVillas()
        {
            var villas = _context.Villas.ToList();

            return Ok(villas);
        }

        [HttpGet("GetVillas")]
        public IActionResult GetVillas()
        {
            return Ok("Welcome to the Marvelous Villas API!");
        }

        [HttpGet("GetVillaNumber{id:int:min(1)}")]
        public IActionResult GetVillaNumber(int id)
        {
            return Ok($"Villa Number {id}");
        }

        [HttpGet("SearchVillas/{keyword}")]
        public IActionResult SearchVillas(string keyword)
        {
            return Ok($"Search for Vill: {keyword}");
        }

        [HttpGet("GetVillaById{id:int:min(1)}")]
        public IActionResult GetVillaById(int id)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            var villaDto = _mapper.Map<VillaDTO>(villa);

            return Ok(villa);
        }

        [HttpPost("CreateVilla")]
        public IActionResult CreateVilla(VillaDTO villaDto)
        {
            var newVilla = _mapper.Map<Villa>(villaDto);

            _context.Villas.Add(newVilla);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetVillaById), new { id = newVilla.Id }, newVilla);
        }

        [HttpDelete("DeleteVilla{id:int}")]
        public IActionResult DeleteVilla(int id)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            _context.Villas.Remove(villa);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("CreateVillaWithRequest")]
        public IActionResult CreateVillaWithRequest([FromBody] VillaDTO villa)
        {
            if (villa == null)
            {
                return BadRequest("اطلاعات ویلا نمی‌تواند خالی باشد.");
            }

            return Ok(villa);
        }

        [HttpGet("GetVillaTwo{id:int}")]
        public ActionResult<VillaDTO> GetVillaTwo(int id)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

    }
}

// https://chatgpt.com/c/6900e1af-5348-832f-829d-a4972d76caea
// https://chatgpt.com/c/69022897-05a8-8326-97e2-8d5619a04092
// https://chatgpt.com/c/69023129-d2f8-8332-9993-84383eedb4c0
// https://chatgpt.com/c/69027916-4be8-8324-87ad-761db89b985d
// https://chatgpt.com/c/6902a16e-bce8-832b-b36e-3f2f0ad033d9

// Create a controller call it Mason
// GetAllVillas()  GET / api / villa  200 OK + list of DTOs	Returns all villas
// GetVillaById(id)	GET /api/villa/7	200 OK or 404 NotFound	Returns one villa
// CreateVilla()	POST /api/villa	201 Created + new DTO Creates new villa
// Return proper error messages and status codes
// Use AutoMapper for mapping between entities and DTOs
// Use Entity Framework Core for data access
// Use dependency injection for DbContext and AutoMapper
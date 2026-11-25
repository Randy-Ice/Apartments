using Apartments.Data;
using Apartments.Features.V1.Apartments.DTO;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace Apartments.Features.V1.Apartments
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly ProjectDB _db;
        public ApartmentsController(ProjectDB db)
        {
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var apartments = await _db.Apartments
                .Include(x => x.Address)
                .Where(x => x.IsAvailable)
                .ToListAsync();
            return Ok(apartments.Adapt<IEnumerable<GetApartmentSimpleDTO>>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var apartments = await _db.Apartments
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (apartments == null)
            {
                return NotFound();
            }
            return Ok(apartments.Adapt<GetApartmentDetailsDTO>());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateApartmentDTO dto)
        {
            var apartments = dto.Adapt<Apartment>();
            await _db.AddAsync(apartments);
            await _db.SaveChangesAsync();
            var results = apartments.Adapt<GetApartmentDetailsDTO>();
            return CreatedAtAction(nameof(GetById), new { id = apartments.Id }, results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateApartmentDTO dto)
        {
            var apartments = await _db.Apartments.FirstOrDefaultAsync(x => x.Id == id);
            if (apartments == null)
            {
                return NotFound();
            }
            dto.Adapt(apartments);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var apartments = await _db.Apartments.FirstOrDefaultAsync(x => x.Id == id);
            if (apartments == null)
            {
                return NotFound();
            }
            _db.Remove(apartments);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}

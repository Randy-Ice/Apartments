using Apartments.Data;
using Apartments.Features.V1.ClientApartment.DTO;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace Apartments.Features.V1.ClientApartment
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Client_ApartmentController : ControllerBase
    {
        private readonly ProjectDB _db;
        public Client_ApartmentController(ProjectDB db)
        {
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var client_apartment = await _db.ClientToApartment
                //.Include(x => x.Tenant)
                //.Include(x => x.Apartment)
                //    .ThenInclude(a => a.Address)
                .ToListAsync();
            return Ok(client_apartment.Adapt<IEnumerable<GetClientApartmentSimpleDTO>>());

        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin, Client")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var client_apartment = await _db.ClientToApartment
                .Include(x => x.Tenant)
                .Include(x => x.Apartment)
                    .ThenInclude(a => a.Address)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (client_apartment == null)
            {
                return NotFound();
            }
            return Ok(client_apartment.Adapt<GetClientApartmentDetailsDTO>());
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateClientApartmentDTO dto)
        {
            var client_apartment = dto.Adapt<ClientToApartment>();
            await _db.AddAsync(client_apartment);
            await _db.SaveChangesAsync();
            var results = dto.Adapt<GetClientApartmentDetailsDTO>();
            return CreatedAtAction(nameof(GetById), new { id = client_apartment.Id }, results);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, UpdateClientApartmentDTO dto)
        {
            var client_apartment = await _db.ClientToApartment.FirstOrDefaultAsync(x => x.Id == id);
            if (client_apartment == null)
            {
                return NotFound();
            }
            dto.Adapt(client_apartment);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client_apartment = await _db.ClientToApartment.FirstOrDefaultAsync(x => x.Id == id);
            if (client_apartment == null)
            {
                return NotFound();
            }
            _db.Remove(client_apartment);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}

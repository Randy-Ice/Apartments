using Apartments.Data;
using Apartments.Features.V1.Tenants.DTO;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apartments.Features.V1.Tenants
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ProjectDB _db;
        public TenantController(ProjectDB db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tenant = await _db.Tenants.ToListAsync();
            return Ok(tenant.Adapt<IEnumerable<GetTenantDTO>>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tenant = await _db.Tenants.FirstOrDefaultAsync(x => x.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }
            return Ok(tenant.Adapt<GetTenantDTO>());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTenantDTO dto)
        {
            var tenant = dto.Adapt<Tenant>();
            await _db.AddAsync(tenant);
            await _db.SaveChangesAsync();
            var results = tenant.Adapt<GetTenantDTO>();
            return CreatedAtAction(nameof(GetById), new { id = tenant.Id }, results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateTenantDTO dto)
        {
            var tenant = await _db.Tenants.FirstOrDefaultAsync(x => x.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }
            dto.Adapt(tenant);
            await _db.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tenant = await _db.Tenants.FirstOrDefaultAsync(x => x.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }
            _db.Remove(tenant);
            await _db.SaveChangesAsync();
            return NoContent();
        }



    }
}

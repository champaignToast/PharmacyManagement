using Microsoft.AspNetCore.Mvc;
using PharmacyManagementAPI.Models;
using PharmacyManagementAPI.Services;

namespace PharmacyManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _service;

        public PharmacyController(IPharmacyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPharmacies()
        {
            var pharmacies = await _service.GetAllPharmaciesAsync();

            if (pharmacies == null || !pharmacies.Any())
            {
                return NoContent();
            }

            return Ok(pharmacies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPharmacyById(int id)
        {
            var pharmacy = await _service.GetPharmacyByIdAsync(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            return Ok(pharmacy);
        }

        [HttpPost()]
        public async Task<ActionResult> AddPharmacy([FromBody] PharmacyModel pharmacy)
        {
            if (pharmacy == null)
            {
                return BadRequest();
            }

            var addedPharmacy = await _service.AddPharmacyAsync(pharmacy);
            return CreatedAtAction(nameof(GetPharmacyById), new { id = addedPharmacy.Id }, addedPharmacy);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePharmacy([FromBody] PharmacyModel pharmacy)
        {
            var updatedPharmacy = await _service.UpdatePharmacyAsync(pharmacy);

            if (updatedPharmacy == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

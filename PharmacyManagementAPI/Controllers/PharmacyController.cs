using Microsoft.AspNetCore.Mvc;
using PharmacyManagementAPI.Models;
using PharmacyManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            try
            {
                var pharmacies = await _service.GetAllPharmaciesAsync();

                if (pharmacies == null || !pharmacies.Any())
                {
                    return NoContent();
                }

                return Ok(pharmacies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPharmacyById(int id)
        {
            try
            {
                var pharmacy = await _service.GetPharmacyByIdAsync(id);
                return Ok(pharmacy);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddPharmacy([FromBody] PharmacyModel pharmacy)
        {
            if (pharmacy == null)
            {
                return BadRequest("Pharmacy data is null.");
            }

            try
            {
                var addedPharmacy = await _service.AddPharmacyAsync(pharmacy);
                return CreatedAtAction(nameof(GetPharmacyById), new { id = addedPharmacy.Id }, addedPharmacy);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePharmacy([FromBody] PharmacyModel pharmacy)
        {
            if (pharmacy == null)
            {
                return BadRequest("Pharmacy data is null.");
            }

            try
            {
                var updatedPharmacy = await _service.UpdatePharmacyAsync(pharmacy);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

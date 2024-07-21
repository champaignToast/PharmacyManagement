using Microsoft.AspNetCore.Mvc;
using PharmacyManagementAPI.Models;
using PharmacyManagementAPI.Services;
using PharmacyManagementAPI.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace PharmacyManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _service;

        public PharmacyController(IPharmacyService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAllPharmacies")]
        public IActionResult GetAllPharmacies()
        {
            var pharmacies = _service.GetAllPharmacies();
            return Ok(pharmacies);
        }

        [HttpGet("getPharmacy/{id}")]
        //[Route("getPharmacyById")]
        public IActionResult GetPharmacyById(int id)
        {
            var pharmacy = _service.GetPharmacyById(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            return Ok(pharmacy);
        }

        [HttpPost("addPharmacy")]
        //Route("AddPharmacy")]
        public IActionResult AddPharmacy([FromBody] PharmacyCreateDTO pharmacyDTO)
        {
            if (pharmacyDTO == null)
            {
                return BadRequest();
            }
            var pharmacyModel = new Pharmacy
            {
                Name = pharmacyDTO.Name,
                Address = pharmacyDTO.Address,
                City = pharmacyDTO.City,
                State = pharmacyDTO.State,
                Zip = pharmacyDTO.Zip,
                NumberOfFilledPrescriptions = pharmacyDTO.NumberOfFilledPrescriptions,
                CreatedDate = pharmacyDTO.CreatedDate,
                UpdatedDate = DateTime.Now,

            };
            
            _service.AddPharmacy(pharmacyModel);
            return CreatedAtAction(nameof(GetPharmacyById), new { id = pharmacyModel.Id }, pharmacyModel);
        }

        [HttpPut("updatePharmacy/{id}")]
        //[Route("UpdatePharmacy")]
        public IActionResult UpdatePharmacy(int id, [FromBody] Pharmacy pharmacy)
        {
            if (pharmacy == null || pharmacy.Id != id)
            {
                return BadRequest();
            }
            var existingPharmacy = _service.GetPharmacyById(id);
            if (existingPharmacy == null)
            {
                return NotFound();
            }
            existingPharmacy.Name = pharmacy.Name;
            existingPharmacy.Address = pharmacy.Address;
            existingPharmacy.City = pharmacy.City;
            existingPharmacy.State = pharmacy.State;
            existingPharmacy.Zip = pharmacy.Zip;
            existingPharmacy.NumberOfFilledPrescriptions = pharmacy.NumberOfFilledPrescriptions;
            existingPharmacy.CreatedDate = pharmacy.CreatedDate; 
            existingPharmacy.UpdatedDate = DateTime.Now;
            _service.UpdatePharmacy(existingPharmacy);
            return NoContent();
        }
    }

}

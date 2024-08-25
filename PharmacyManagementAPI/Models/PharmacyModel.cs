using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyManagementAPI.Models
{
    public class PharmacyModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(100, ErrorMessage = "City cannot be longer than 100 characters")]
        public string? City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid Zip Code format")]
        public string? Zip { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Number of filled prescriptions must be a non-negative number")]
        public int? NumberOfFilledPrescriptions { get; set; }

        [Required(ErrorMessage = "Created Date is required")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Updated Date is required")]
        public DateTime? UpdatedDate { get; set; }
    }
}


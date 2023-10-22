using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.DTOs
{
    public class EmployeeInputDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(20)]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]
        public Guid? DepartmentId { get; set; }

        [Required(ErrorMessage = "IsStillWorking is required")]
        public bool IsStillWorking { get; set; }
        public IFormFile? Photo { get; set; }
    }
}

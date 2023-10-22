using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Models
{
    public class EmployeeOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Guid? DepartmentId { get; set; }
        public DepartmentOutputDto? Department { get; set; }

        public bool IsStillWorking { get; set; }

        public string? CreatedById { get; set; }
        public byte[]? Photo { get; set; }
        public UserOutputDto? CreatedBy { get; set; }
    }
}

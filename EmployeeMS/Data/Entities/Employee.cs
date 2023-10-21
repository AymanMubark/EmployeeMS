using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMS.Data.Entities
{
    public class Employee : BaseEnitiy
    {
        [MaxLength(150)]
        public string Name { get; set; } = null!;
        [MaxLength(100)]
        public string Email { get; set; } = null!;
        [MaxLength(20)]
        public string Phone { get; set; } = null!;

        [Column("DepartmentId")]
        public Guid? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public bool  IsStillWorking { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

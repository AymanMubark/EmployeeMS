using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Data.Entities
{
    public class BaseEnitiy
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

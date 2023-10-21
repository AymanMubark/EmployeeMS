using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.Data.Entities
{
    public class Department : BaseEnitiy
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}

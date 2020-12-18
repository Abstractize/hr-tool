using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Server.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            EmployeeDatumIdEmployeeNavigations = new HashSet<EmployeeData>();
            EmployeeDatumIdManagerNavigations = new HashSet<EmployeeData>();
        }

        [Key]
        public int IdEmployee { get; set; }
        [Required]
        [StringLength(255)]
        public string EmployeeId { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [InverseProperty(nameof(EmployeeData.IdEmployeeNavigation))]
        public virtual ICollection<EmployeeData> EmployeeDatumIdEmployeeNavigations { get; set; }
        [InverseProperty(nameof(EmployeeData.IdManagerNavigation))]
        public virtual ICollection<EmployeeData> EmployeeDatumIdManagerNavigations { get; set; }

        public static Employee Empty
        {
            get => new Employee
            {
                IdEmployee = 0,
                EmployeeId = "",
                IsActive = true,
                EmployeeDatumIdEmployeeNavigations = new List<EmployeeData>(),
                EmployeeDatumIdManagerNavigations = new List<EmployeeData>()
            };
        }
    }
}

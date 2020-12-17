using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Server.Models
{
    /// <summary>
    /// EmployeeData model for Database.
    /// </summary>
    public partial class EmployeeData
    {
        [Key]
        public int IdEmployeeData { get; set; }
        public int IdEmployee { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int IdImage { get; set; }
        [Required]
        [StringLength(255)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime HireDate { get; set; }
        public int? IdManager { get; set; }

        [ForeignKey(nameof(IdEmployee))]
        [InverseProperty(nameof(Employee.EmployeeDatumIdEmployeeNavigations))]
        public virtual Employee IdEmployeeNavigation { get; set; }
        [ForeignKey(nameof(IdImage))]
        [InverseProperty(nameof(Image.EmployeeData))]
        public virtual Image IdImageNavigation { get; set; }
        [ForeignKey(nameof(IdManager))]
        [InverseProperty(nameof(Employee.EmployeeDatumIdManagerNavigations))]
        public virtual Employee IdManagerNavigation { get; set; }
        /// <summary>
        /// Returns Empty EmployeeData Model.
        /// </summary>
        public static EmployeeData Empty { get => new EmployeeData{
                IdEmployeeData = 0,
                IdEmployee = 0,
                RegisterDate = DateTime.Now,
                Name = "",
                IdImage = 0,
                PhoneNumber = "",
                Email = "",
                HireDate = DateTime.Now,
                IdManager = 0,
                IdEmployeeNavigation = Employee.Empty,
                IdImageNavigation = Image.Empty,
                IdManagerNavigation = Employee.Empty
            }; }
    }
}

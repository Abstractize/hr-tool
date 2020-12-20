namespace Server.Controllers.Resources
{
    public class Employee
    {
        public int? Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public Image Picture { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public System.DateTime HireDate { get; set; }
        public string ManagerId { get; set; }

        /// <summary>
        /// Returns an Empty Employee
        /// </summary>
        public static Employee Empty { get =>
                new Employee
                {
                    Id = 0,
                    EmployeeId = "",
                    Name = "",
                    Picture = Image.Empty,
                    PhoneNumber = "",
                    Email = "",
                    HireDate = System.DateTime.Now
                }; }
    }
}

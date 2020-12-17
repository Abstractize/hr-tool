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
    }
}

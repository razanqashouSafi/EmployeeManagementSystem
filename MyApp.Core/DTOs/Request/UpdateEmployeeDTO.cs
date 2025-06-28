namespace MyApp.Core.DTOs.Request
{
    public class UpdateEmployeeDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }


        public string ?PhoneNumber { get; set; }


        public string? Email { get; set; }


        public decimal? Salary { get; set; }


        public string ?Position { get; set; }


        public DateTime? HireDate { get; set; }


        public DateTime? DateOfBirth { get; set; }

        public int? Id { get; set; }
    }
}

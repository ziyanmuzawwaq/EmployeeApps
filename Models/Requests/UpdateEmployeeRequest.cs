using System.ComponentModel.DataAnnotations;

namespace EmployeeApps.Api.Models.Requests
{
    public class UpdateEmployeeRequest
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}

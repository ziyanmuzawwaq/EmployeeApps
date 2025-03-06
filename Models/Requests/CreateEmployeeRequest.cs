using System.ComponentModel.DataAnnotations;

namespace EmployeeApps.Api.Models.Requests
{
    public class CreateEmployeeRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int DepartmentId { get; set; }
    }
}

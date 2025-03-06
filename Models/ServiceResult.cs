namespace EmployeeApps.Api.Models
{
    public class ServiceResult
    {
        public string Message { get; set; } = string.Empty;

        public bool IsError { get; set; }

        public dynamic? Content { get; set; }
    }
}

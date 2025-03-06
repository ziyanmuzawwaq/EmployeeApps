namespace EmployeeApps.Api.Models.Entities
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

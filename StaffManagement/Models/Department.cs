namespace StaffManagement.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Staff Staff { get; set; }

    }
}

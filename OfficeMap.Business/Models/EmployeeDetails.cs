namespace OfficeMap.Business.Models
{
    public class EmployeeDetails
    {
        public Detail Id { get; set; }
        public Detail UserIdentity { get; set; }
        public Detail Name { get; set; }
        public Detail Surname { get; set; }
        public Detail JobTitle { get; set; }
        public Detail Unit { get; set; }
        public Detail Email { get; set; }
        public Detail Phone { get; set; }
        public bool IsSuperUser { get; set; }
    }
}

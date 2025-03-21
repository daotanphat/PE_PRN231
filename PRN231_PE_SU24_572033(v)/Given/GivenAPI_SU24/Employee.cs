namespace GivenAPI_SU24
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateOfBirth Dob { get; set; }
        public string Position { get; set; }
        public bool IsFullTime { get; set; }
    }

    public class DateOfBirth
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}

namespace ClassLibrary1
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Employer Employer { get; set; }
        public decimal Money { get; set; }
    }

    public class Employer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }

    public enum UserStatus
    {
        Zero = 255,
        Confirmed = 4,
        Active = 8,
        Locked = 16,
        Left = 32,
        Suspended = 64
    }
}

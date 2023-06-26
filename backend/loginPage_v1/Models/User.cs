namespace loginPage_v1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; } = null;
        public string Password { get; set; }
        public string UserName { get; set; }
        public string NumberPrefix { get; set; }
        public string PhoneNumber { get; set; }
    }
}
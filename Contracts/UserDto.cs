namespace BackendAPI.Models.Contracts
{
    public class UserDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string? City { get; set; }
        public string Passkey { get; set; } = null!;
        public int RoleId { get; set; }
        public string UserName { get; set; } = null!;
    }
}

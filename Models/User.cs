using System;
using System.Collections.Generic;

namespace BackendAPI.Models
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string? City { get; set; }
        public DateTime? EditTime { get; set; }
        public string Passkey { get; set; } = null!;
        public int RoleId { get; set; }
        public string UserName { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Post> Posts { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BackendAPI.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Posts = new HashSet<Post>();
        }

        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = null!;
        public int? AddedBy { get; set; }
        public DateTime? AddedTime { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteTime { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual ICollection<Post> Posts { get; set; }
    }
}

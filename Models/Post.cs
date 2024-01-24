using System;
using System.Collections.Generic;

namespace BackendAPI.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public byte[]? Photo { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? EditTime { get; set; }
        public int? DeleteBy { get; set; }
        public DateTime? DeleteTime { get; set; }
        public int CategoryId { get; set; }

        public virtual Comment Comment { get; set; } = null!;
        public virtual User CommentNavigation { get; set; } = null!;
        public virtual Category PostNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}

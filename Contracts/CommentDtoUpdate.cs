namespace BackendAPI.Models.Contracts
{
    public class CommentDtoUpdate
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = null!;
        public int? AddedBy { get; set; }
        public int? DeleteBy { get; set; }
    }
}

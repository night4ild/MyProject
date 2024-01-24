﻿namespace BackendAPI.Contracts
{
    public class PostDto
    {
        public int CommentId { get; set; }
        
        public int UserId { get; set; }
        public byte[]? Photo { get; set; }
        public int? AddedBy { get; set; }
        public int? DeleteBy { get; set; }
        public int CategoryId { get; set; }
    }
}
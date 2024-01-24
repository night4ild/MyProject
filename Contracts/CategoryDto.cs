namespace BackendAPI.Models.Contracts
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public virtual Post? Post { get; set; }
    }
}

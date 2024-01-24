namespace BackendAPI.Models.Contracts
{
    public class CategoryDtoUpdate
    {
        public string CategoryName { get; set; } = null!;
        public virtual Post? Post { get; set; }
    }
}

namespace UnionMarket.DTOs
{
    public class CategoryTreeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public List<CategoryTreeDto> Children { get; set; } = new();

    }
}

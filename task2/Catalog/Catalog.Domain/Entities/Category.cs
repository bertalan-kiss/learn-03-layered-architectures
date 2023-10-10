namespace Catalog.Domain.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Category Parent { get; set; }
    }
}

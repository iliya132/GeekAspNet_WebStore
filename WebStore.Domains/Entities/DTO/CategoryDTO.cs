using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities.DTO
{
    public class CategoryDTO : INamedEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
    }
}

using Catalog.Domain.Entities;

namespace Catalog.Application.Interfaces
{
    public interface IItemRepository
    {
        void Add(Item item);
        Item Get(int id);
        IEnumerable<Item> List();
        void Update(Item category);
        void Delete(int id);
    }
}


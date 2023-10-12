using Catalog.Domain.Entities;

namespace Catalog.Application.Services
{
	public interface IItemService
	{
		void Add(Item item);
		Item Get(int id);
        IEnumerable<Item> List();
        void Update(Item category);
        void Delete(int id);
    }
}


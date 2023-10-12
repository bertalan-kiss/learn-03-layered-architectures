using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;

namespace Catalog.Application.Services
{
    public class ItemService : IItemService
	{
        private readonly IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public void Add(Item item)
        {
            itemRepository.Add(item);
        }

        public void Delete(int id)
        {
            itemRepository.Delete(id);
        }

        public Item Get(int id)
        {
            return itemRepository.Get(id);
        }

        public IEnumerable<Item> List()
        {
            return itemRepository.List();
        }

        public void Update(Item category)
        {
            itemRepository.Update(category);
        }
    }
}


using Catalog.Application.Interfaces;
using Catalog.Application.Validators;
using Catalog.Domain.Entities;
using FluentValidation;

namespace Catalog.Application.Services
{
    public class ItemService : IItemService
	{
        private readonly IItemRepository itemRepository;
        private readonly ItemValidator itemValidator;

        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
            itemValidator = new ItemValidator();
        }

        public async Task<int> Add(Item item)
        {
            await itemValidator.ValidateAndThrowAsync(item);

            return await itemRepository.Add(item);
        }

        public async Task Delete(int id)
        {
            await itemRepository.Delete(id);
        }

        public async Task<Item> Get(int id)
        {
            return await itemRepository.Get(id);
        }

        public async Task<IEnumerable<Item>> List()
        {
            return await itemRepository.List();
        }

        public async Task Update(Item item)
        {
            await itemValidator.ValidateAndThrowAsync(item);

            await itemRepository.Update(item);
        }
    }
}


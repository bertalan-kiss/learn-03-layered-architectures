using Carting.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Carting.Infrastructure
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddInfrastuctureRepositories(this IServiceCollection collection)
		{
			collection.AddTransient<ICartingRepository, CartingRepository>();
			return collection;
        }
	}
}


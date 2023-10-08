﻿using Carting.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Carting.Core
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddCoreServices(this IServiceCollection collection)
		{
			collection.AddTransient<ICartingService, CartingService>();
			return collection;
        }
	}
}


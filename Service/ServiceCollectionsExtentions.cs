using Domain.ServiceInterfaces;
using Domain.ServiceInterfacesHuman;
using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public static class ServiceCollectionsExtentions
    {
        public static void AddFurnitureService(this IServiceCollection services)
        {
            services.AddScoped<IFurnitureService, FurnitureService>();
        }

        public static void AddHumanService(this IServiceCollection services)
        {
            services.AddScoped<IHumanService, HumanService>();
        }

        public static void AddOrderService(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}

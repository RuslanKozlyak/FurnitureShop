using Domain.RepositoryInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Service
{
    public static class ServiceCollectionsExtentions
    {
        public static void AddGenericRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}

using Ecommerce.Core.Interface;
using Ecommerce.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Data
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure
            (this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

             services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();

        }
    }
}

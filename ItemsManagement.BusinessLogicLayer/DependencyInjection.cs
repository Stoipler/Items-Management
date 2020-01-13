using ItemsManagement.BusinessLogicLayer.Services;
using ItemsManagement.BusinessLogicLayer.Services.Interfaces;
using ItemsManagement.DataAccessLayer.AppContext;
using ItemsManagement.DataAccessLayer.Repositories.EntityFrameworkRepositories;
using ItemsManagement.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItemsManagement.BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static void OnLoad(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationDatabase")));

            services.AddTransient<IItemRepository, ItemRepository>();

            services.AddTransient<IItemService, ItemService>();
        }
    }
}

using Microsoft.AspNetCore.Components.Authorization;
using SmartMngShop.Web.Services;
namespace SmartMngShop.Web.Extensions.FrameworkExtensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddCascadingAuthenticationState();
            services.AddScoped<AuthenticationStateProvider, AuthStateRevalidation>();

            return services; 
        }
    }
}

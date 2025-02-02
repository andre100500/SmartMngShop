﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using SmartMngShop.Web.Services;
namespace SmartMngShop.Web.Extensions.FrameworkExtensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddCascadingAuthenticationState();
            services.AddScoped<AuthenticationStateProvider, AuthStateRevalidation>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;

            })
                .AddIdentityCookies();

            services.AddScoped<CookieEvents>();
            services.ConfigureApplicationCookie(options =>
            {
                options.EventsType = typeof(CookieEvents);
            });
            services.AddAuthorization(); // for future customer ?? TODO Created Font-end Claim navMenu 
            return services; 
        }
    }
}

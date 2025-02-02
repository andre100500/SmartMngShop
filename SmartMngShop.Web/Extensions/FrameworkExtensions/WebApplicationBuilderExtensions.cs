﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartMngShop.Web.Data;

namespace SmartMngShop.Web.Extensions.FrameworkExtensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder ConfigureIdentity(this WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContextFactory<AppDbContext>(opt=> opt.UseSqlServer(cs));
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));
            builder.Services.AddIdentityCore<IdentityUser>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 5;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.ClaimsIdentity.UserIdClaimType = "smartMngShopID";
            })
                .AddRoles<IdentityRole>()
                .AddSignInManager()
                .AddEntityFrameworkStores<AppDbContext>();

            return builder;
        }
    }
}

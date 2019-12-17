using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wealthox.Entities.DTOs;
using Wealthox.Services;



namespace Wealthox.Web.Code.ExtensionMethods
{
    public static class ConfigurationExtensionMethods
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<ConstructionMaterialService>();
            services.AddScoped<UserAccountService>();
            services.AddScoped<RoleService>();
            services.AddScoped<AnnouncementService>();
            services.AddScoped<HouseService>();
            return services;
        }

        public static IServiceCollection AddCurrentUser(this IServiceCollection services)
        {
            services.AddScoped(serviceProvider =>
            {
                var contextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
                var context = contextAccessor.HttpContext;
                var mail = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty;
                var userService = serviceProvider.GetService<UserAccountService>();
                var roleService = serviceProvider.GetService<RoleService>();

                var user = userService.Get(mail);

                if (user != null)
                {
                    var isAdmin = roleService.CheckAdmin(user.Id);
                    return new CurrentUser(isAuthenticated: true, isAdmin: isAdmin)
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                    };
                }
                else
                    return new CurrentUser(isAuthenticated: false, isAdmin: false);

            });

            return services;
        }
    }

}

using Microsoft.EntityFrameworkCore;
using LawAlert.Controllers;
using LawAlert.Core.Services;
using LawAlert.Core.Services.User;
using LawAlert.Core.Services.Interest;
using LawAlert.Core.Services.Law;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LawAlertServiceCollectionExtension
    {
        public static IServiceCollection AddLawAlertServices(this IServiceCollection services)
        {
            services.AddScoped<ILogger, Logger<UserController>>();
            services.AddScoped<ILogger, Logger<LawController>>();
            services.AddScoped<ILogger, Logger<UserService>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILawService, LawService>();
            services.AddScoped<IInterestService, InterestService>();

            return services;
        }
    }
}

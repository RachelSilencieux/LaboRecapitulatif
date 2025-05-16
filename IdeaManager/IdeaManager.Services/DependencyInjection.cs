using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaManager.Core.Interfaces;
using IdeaManager.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IdeaManager.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIdeaService, IdeaService>();
            services.AddScoped<IVoteService, VoteService>();
            services.AddScoped<IProjectService, ProjectService>();
            return services;
        }
    }
}

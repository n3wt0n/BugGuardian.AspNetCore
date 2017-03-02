using BugGuardian.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BugGuardian.AspNetCore.Middlewares
{
    public class BugGuardianBaseMiddleware
    {
        internal readonly RequestDelegate _next;

        public BugGuardianBaseMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;

            var bugGuardianConfiguration = configuration.BuildBugGuardianConfiguration();

            DBTek.BugGuardian.Factories.ConfigurationFactory.SetConfiguration(bugGuardianConfiguration.Url,
                bugGuardianConfiguration.Username,
                bugGuardianConfiguration.Password,
                bugGuardianConfiguration.CollectiontName,
                bugGuardianConfiguration.ProjectName,
                bugGuardianConfiguration.AvoidMultipleReport);
        }
    }
}

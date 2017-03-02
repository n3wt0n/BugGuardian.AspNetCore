using BugGuardian.AspNetCore.Config;
using BugGuardian.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BugGuardian.AspNetCore.Middlewares
{
    public class BugGuardianBaseMiddleware
    {
        internal readonly RequestDelegate _next;
        internal readonly BugGuardianMiddlewareOptions _options;

        public BugGuardianBaseMiddleware(RequestDelegate next, IConfiguration configuration, IOptions<BugGuardianMiddlewareOptions> options)
        {
            _next = next;
            _options = options.Value;
            //_configuration = configuration;

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

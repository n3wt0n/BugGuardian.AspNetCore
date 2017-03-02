using BugGuardian.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BugGuardian.AspNetCore.Middlewares
{
    public class BugGuardianBaseMiddleware
    {
        internal readonly RequestDelegate _next;
        internal readonly string[] _tags;

        public BugGuardianBaseMiddleware(RequestDelegate next, IConfiguration configuration) : this(next, configuration, null) { }

        public BugGuardianBaseMiddleware(RequestDelegate next, IConfiguration configuration, string[] tags)
        {
            _next = next;
            _tags = tags;

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

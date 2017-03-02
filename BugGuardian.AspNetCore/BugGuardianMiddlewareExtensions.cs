using BugGuardian.AspNetCore.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BugGuardian.AspNetCore
{
    public static class BugGuardianMiddlewareExtensions
    {
        public static IApplicationBuilder UseBugGuardianBugExceptionHandler(this IApplicationBuilder builder, IConfiguration configuration)
            => builder.UseMiddleware<Middlewares.BugGuardianBugMiddleware>(configuration);

        public static IApplicationBuilder UseBugGuardianBugExceptionHandler(this IApplicationBuilder builder, IConfiguration configuration, IOptions<BugGuardianMiddlewareOptions> options)
            => builder.UseMiddleware<Middlewares.BugGuardianBugMiddleware>(configuration, options);
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;

namespace BugGuardian.AspNetCore
{
    public static class BugGuardianMiddlewareExtensions
    {
        public static IApplicationBuilder UseBugGuardianBugExceptionHandler(this IApplicationBuilder builder, IConfiguration configuration)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.UseMiddleware<Middlewares.BugGuardianBugMiddleware>(configuration);
        }

        public static IApplicationBuilder UseBugGuardianBugExceptionHandler(this IApplicationBuilder builder, IConfiguration configuration, string[] tags)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.UseMiddleware<Middlewares.BugGuardianBugMiddleware>(configuration, tags);
        }

        public static IApplicationBuilder UseBugGuardianTaskExceptionHandler(this IApplicationBuilder builder, IConfiguration configuration)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.UseMiddleware<Middlewares.BugGuardianTaskMiddleware>(configuration);
        }

        public static IApplicationBuilder UseBugGuardianTaskExceptionHandler(this IApplicationBuilder builder, IConfiguration configuration, string[] tags)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder.UseMiddleware<Middlewares.BugGuardianTaskMiddleware>(configuration, tags);
        }
    }
}

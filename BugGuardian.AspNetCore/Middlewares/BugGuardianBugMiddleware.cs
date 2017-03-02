using BugGuardian.AspNetCore.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BugGuardian.AspNetCore.Middlewares
{
    public class BugGuardianBugMiddleware : BugGuardianBaseMiddleware
    {
        public BugGuardianBugMiddleware(RequestDelegate next, IConfiguration configuration, IOptions<BugGuardianMiddlewareOptions> options) : base(next, configuration, options) { }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                using (var manager = new DBTek.BugGuardian.BugGuardianManager())
                {
                    if (_options.tags != null && _options.tags.Any())
                        await manager.AddBugAsync(ex, tags: _options.tags);
                    else
                        await manager.AddBugAsync(ex);
                }
            }
        }
    }
}

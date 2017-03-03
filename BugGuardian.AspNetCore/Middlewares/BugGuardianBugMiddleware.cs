using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DBTek.BugGuardian.AspNetCore.Middlewares
{
    public class BugGuardianBugMiddleware : BugGuardianBaseMiddleware
    {
        public BugGuardianBugMiddleware(RequestDelegate next, IConfiguration configuration) : base(next, configuration) { }

        public BugGuardianBugMiddleware(RequestDelegate next, IConfiguration configuration, string[] tags) : base(next, configuration, tags) { }

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
                    if (_tags != null && _tags.Any())
                        await manager.AddBugAsync(ex, tags: _tags);
                    else
                        await manager.AddBugAsync(ex);
                }

                throw; //re-throw the Exception to be used in other middlewares
            }
        }
    }
}

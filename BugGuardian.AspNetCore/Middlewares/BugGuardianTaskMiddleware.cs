using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DBTek.BugGuardian.AspNetCore.Middlewares
{
    public class BugGuardianTaskMiddleware : BugGuardianBaseMiddleware
    {
        public BugGuardianTaskMiddleware(RequestDelegate next, IConfiguration configuration) : base(next, configuration) { }

        public BugGuardianTaskMiddleware(RequestDelegate next, IConfiguration configuration, string[] tags) : base(next, configuration, tags) { }

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
                        await manager.AddTaskAsync(ex, tags: _tags);
                    else
                        await manager.AddTaskAsync(ex);
                }

                throw; //re-throw the Exception to be used in other middlewares
            }
        }
    }
}

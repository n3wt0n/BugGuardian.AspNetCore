using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace BugGuardian.AspNetCore.Middlewares
{
    public class BugGuardianTaskMiddleware : BugGuardianBaseMiddleware
    {
        public BugGuardianTaskMiddleware(RequestDelegate next, IConfiguration configuration) : base(next, configuration) { }

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
                    await manager.AddTaskAsync(ex);
                }

                throw; //re-throw the Exception to be used in other middlewares
            }
        }
    }
}

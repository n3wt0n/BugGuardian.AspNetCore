using System.Collections.Generic;

namespace BugGuardian.AspNetCore.Config
{
    public class BugGuardianMiddlewareOptions
    {
        public IEnumerable<string> tags { get; set; }
    }
}

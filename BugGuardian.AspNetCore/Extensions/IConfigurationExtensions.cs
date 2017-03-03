using DBTek.BugGuardian.AspNetCore.Config;
using Microsoft.Extensions.Configuration;

namespace DBTek.BugGuardian.AspNetCore.Extensions
{
    internal static class IConfigurationExtensions
    {
        private const string DefaultCollectionName = "DefaultCollection";

        internal static BugGuardianConfiguration BuildBugGuardianConfiguration(this IConfiguration configuration)
            => new BugGuardianConfiguration()
            {
                Url = configuration["Url"],
                Username = configuration["Username"],
                Password = configuration["Password"],
                CollectiontName = configuration["CollectionName"] ?? DefaultCollectionName,
                ProjectName = configuration["ProjectName"],
                AvoidMultipleReport = bool.Parse(configuration["AvoidMultipleReport"] ?? "true")
            };
    }
}

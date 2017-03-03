namespace DBTek.BugGuardian.AspNetCore.Config
{
    internal class BugGuardianConfiguration
    {
        internal string Url { get; set; }
        internal string Username { get; set; }
        internal string Password { get; set; }
        internal string CollectiontName { get; set; }
        internal string ProjectName { get; set; }
        internal bool AvoidMultipleReport { get; set; }
    }
}

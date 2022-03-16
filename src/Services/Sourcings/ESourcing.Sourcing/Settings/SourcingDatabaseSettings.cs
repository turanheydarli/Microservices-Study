using ESourcing.Sourcings.Settings.Interfaces;

namespace ESourcing.Sourcings.Settings
{
    public class SourcingDatabaseSettings : ISourcingDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

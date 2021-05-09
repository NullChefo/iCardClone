namespace iCard.ApplicationServices.DTOs
{
    public class SettingsDTO
    {
        public int? Id { get; set; }
        public string AppTheme { get; set; }

        public bool GamblingBlock { get; set; }

        public bool AppNotifications { get; set; }

        public bool AutoUpdate { get; set; }

        public string Name { get; set; }
    }
}
namespace SMARTHardDrive.Models
{
    public class DashboardViewModel
    {
        public int TotalHardDrives { get; set; }
        public int WorkingHardDrives { get; set; }
        public int FaultyHardDrives { get; set; }
        public List<Alert> Alerts { get; set; }
    }
}

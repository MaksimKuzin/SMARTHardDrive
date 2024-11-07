using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SMARTHardDrive.Models
{
    public class HardDrive
    {
        public int Id { get; set; }

        [DisplayName("Серийный номер")]
        [MaxLength(50)]
        public string SerialNumber { get; set; }

        [DisplayName("Модель")]
        [Required, MaxLength(30)]
        public string Model { get; set; }

        [DisplayName("Емкость (ГБ)")]
        public int CapacityGB { get; set; }

        [DisplayName("Тип подключения")]
        [MaxLength(30)]
        public string ConnectionType { get; set; }

        [DisplayName("Дата установки")]
        public DateTime InstallDate { get; set; }

        [DisplayName("Местоположение")]
        [MaxLength(100)]
        public string Location { get; set; }

        [DisplayName("Статус")]
        [MaxLength(30)]
        public string Status { get; set; }

        public List<SMARTData> SMARTData { get; set; }
        public List<Maintenance> Maintenances { get; set; }
        public List<Alert> Alerts { get; set; }
    }
}

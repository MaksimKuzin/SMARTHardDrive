using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SMARTHardDrive.Models
{
    public class Alert
    {
        public int Id { get; set; }

        [DisplayName("Тип оповещения")]
        [Required, MaxLength(30)]
        public string Type { get; set; }

        [DisplayName("Описание оповещения")]
        public string Description { get; set; }

        [DisplayName("Дата и время оповещения")]
        public DateTime Date { get; set; }

        [DisplayName("Уровень важности")]
        [MaxLength(30)]
        public string Severity { get; set; }

        [DisplayName("Статус")]
        [MaxLength(30)]
        public string Status { get; set; }

        public List<HardDrive> HardDrives { get; set; }
    }
}

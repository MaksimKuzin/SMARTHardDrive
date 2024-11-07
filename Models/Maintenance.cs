using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SMARTHardDrive.Models
{
    public class Maintenance
    {
        public int Id { get; set; }

        [DisplayName("Дата обслуживания")]
        public DateTime Date { get; set; }

        [DisplayName("Описание обслуживания")]
        public string Description { get; set; }

        [DisplayName("Исполнитель")]
        [MaxLength(50)]
        public string PerformedBy { get; set; }

        [DisplayName("Жесткий диск")]
        public int HardDriveId { get; set; }
        [ForeignKey("HardDriveId")]
        public HardDrive HardDrive { get; set; }
    }
}

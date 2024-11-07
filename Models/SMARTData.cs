using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SMARTHardDrive.Models
{
    public class SMARTData
    {
        public int Id { get; set; }

        [DisplayName("Значение атрибута")]
        public int Value { get; set; }

        [DisplayName("Дата и время записи")]
        public DateTime Date { get; set; }

        [DisplayName("Статус")]
        [MaxLength(30)]
        public string Status { get; set; }

        [DisplayName("Жесткий диск")]
        public int HardDriveId { get; set; }
        [ForeignKey("HardDriveId")]
        public HardDrive HardDrive { get; set; }

        [DisplayName("Атрибут SMART")]
        public int AttributeId { get; set; }
        [ForeignKey("AttributeId")]
        public SMARTAttribute Attribute { get; set; }
    }
}

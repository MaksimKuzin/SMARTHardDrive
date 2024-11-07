using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SMARTHardDrive.Models
{
    public class SMARTAttribute
    {
        public int Id { get; set; }

        [DisplayName("Название атрибута")]
        [Required, MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Код атрибута")]
        public int Code { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Критическое значение")]
        public int Threshold { get; set; }

        [DisplayName("Единица измерения")]
        [MaxLength(30)]
        public string Unit { get; set; }

        public ICollection<SMARTData> SMARTData { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace API.SoapModels
{
    public class ServeyCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
    }
}

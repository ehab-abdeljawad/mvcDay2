using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcDay2.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string locations { get; set; }
        public string city { get; set; }

        [ForeignKey("Departments")]
        public int?     Dno { get; set; }

        public Departments Departments { get; set; }
        public List<Work_for> employees { get; set; }

    }
}

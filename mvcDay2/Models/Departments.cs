using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcDay2.Models
{
    public class Departments
    {
        [Key]
        public int Dnum { get; set; }
        public string Dname { get; set; }

        [ForeignKey("mangeemp")]
        public int? Mgssn { get; set; }

        [InverseProperty("mangedept")]
        public employee mangeemp {  get; set; }


        [InverseProperty("Departments")]
        public List<employee> employees { get; set; }

        public List<Project> projects { get; set; }
    }
}

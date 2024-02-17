using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mvcDay2.Models
{
    public class employee
    {
        [Key]
        public int Ssn { get; set; }
        public string fname {  get; set; }
        public string lname { get; set; }
        public DateOnly  Bdate  { get; set; }
        public string sex { get; set; }
        [Column(TypeName = "money")]
        public decimal salary { get; set; }
        public string address { get; set; }

        [ForeignKey("Departments")]
        public int? Dno { get; set; }
        [ForeignKey("superssn")]
        public int? superid { get; set; }


        public Departments Departments { get; set; }
        public Departments mangedept { get; set; }
        public employee superssn { get; set; }
        [InverseProperty("superssn")]
        public List<employee> group { get; set; }

        public List<Work_for> project {  get; set; }
        public List<Dependent> dependents { get; set; }
    }
}

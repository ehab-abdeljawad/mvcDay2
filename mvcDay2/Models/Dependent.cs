using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcDay2.Models
{
    [PrimaryKey("name", "eSsn")]
    public class Dependent
    {
        [Key]
        public string name { get; set; }
        [ForeignKey("employee")]
        public int eSsn { get; set; }
        public string sex { get; set; }

        public DateOnly Bdate { get; set; }

        public employee employee { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcDay2.Models
{
    [PrimaryKey("eSsn","pno")]
    public class Work_for
    {
        [ForeignKey("employee")]
        public int? eSsn { get; set; }
        [ForeignKey("Project")]
        public int? pno { get; set; }
        public int Houres { get; set; }



        public Project Project { get; set; }
        public employee employee { get; set; }

    }
}

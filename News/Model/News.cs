using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Model
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NewsId { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Priority Priority { get; set; }
        public string Type { get; set; }
    }

    public enum Priority
    {
        P1,
        P2,
        P3
    }

}

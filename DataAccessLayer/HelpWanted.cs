using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HelpWanted
    {
        [Key]
        [Column(Order = 1)]
        public Guid TheaterID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 2)]
        public Guid HelpWantedID { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public Theater theater { get; set; }

        public HelpWanted( Guid theaterID, DateTime dateTime,string jobTitle)
        {
            this.HelpWantedID = Guid.NewGuid();
            this.TheaterID = theaterID;
            this.DateCreated = dateTime;
            this.JobTitle = jobTitle;
        }
    }
}

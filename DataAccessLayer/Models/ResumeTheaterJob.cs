using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ResumeTheaterJob
    {
        [Key]
        [Column(Order = 1)]
        public int HelpWantedID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ResumeID { get; set; }
        public DateTime DateUploaded { get; set; }
        public TheaterJobPosting theaterJobPosting { get; set; }
        public Resume userResume { get; set; }

        ResumeTheaterJob()
        {

        }

        ResumeTheaterJob(int helpid, int resumeid) {
            this.HelpWantedID = helpid;
            this.ResumeID = resumeid;
        }
    }
}

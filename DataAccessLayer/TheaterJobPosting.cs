using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TheaterJobPosting
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
        public string Position { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Hours { get; set; }
        [Required]
        public string Requirements { get; set; }
        public Theater theater { get; set; }

        public TheaterJobPosting( Guid theaterID, DateTime dateTime,string position, string description, string title, string hour, string requirement)
        {
            this.HelpWantedID = Guid.NewGuid();
            this.TheaterID = theaterID;
            this.DateCreated = dateTime;
            this.Position = position;
            this.Description = description;
            this.Title = title;
            this.Hours = hour;
            this.Requirements = requirement;
        }
        public TheaterJobPosting()
        {
            this.Position = "";
            this.Description = "";
            this.Title = "";
            this.Hours = "";
            this.Requirements = "";
        }
    }
}

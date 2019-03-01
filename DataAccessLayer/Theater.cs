using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    [Table("Theaters")]
    public class Theater
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TheaterID { get; set; }
        [Required]
        public string TheaterName { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        

        public virtual ICollection<Production> Production { get; set; }
        public virtual ICollection<UserPermission> userPermissions { get; set; }
        public virtual ICollection<TheaterJobPosting> theaterJobPostings { get; set; }

        public Theater(string theaterName, string companyName, string streetAddress, string city,
            string state, string country, string phoneNumber)
            {
                TheaterID = Guid.NewGuid();
                this.TheaterName = theaterName;
                this.CompanyName = companyName;
                this.StreetAddress = streetAddress;
                this.City = city;
                this.State = state;
                this.Country = country;
                this.PhoneNumber = phoneNumber;
            }            
    }
}

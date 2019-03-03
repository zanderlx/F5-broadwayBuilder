using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccessLayer
{
    [Table("Productions")]
    public class Production
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductionID { get; set; }
        public string ProductionName { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorLastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid TheaterID { get; set; }
        public Theater theater { get; set; }

        public virtual ICollection<ProductionJobPosting> ProductionJobPostings { get; set; }


        public Production(Guid theaterId, string productionName, string directorFirstName, string directorLastName, string street, string city, string stateProvince, string country, string zipcode)
        {
            ProductionID = Guid.NewGuid();
            TheaterID = theaterId;
            ProductionName = productionName;
            DirectorFirstName = directorFirstName;
            DirectorLastName = directorLastName;
            Street = street;
            City = city;
            StateProvince = stateProvince;
            Country = country;
            Zipcode = zipcode;
           
        }

    }
}

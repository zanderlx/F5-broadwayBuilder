using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.DataAccessLayer;

namespace DataAccessLayer
{
    [Table("Productions")]
    public class Production
    {

        public Production(Guid theaterId, string productionName, string directorFirstName, string directorLastName, string productionCity, string productionState, string productionCountry)
        {
            ProductionID = Guid.NewGuid();
            this.TheaterID = theaterId;
            ProductionName = productionName;
            DirectorFirstName = directorFirstName;
            DirectorLastName = directorLastName;
            ProductionCity = productionCity;
            ProductionState = productionState;
            ProductionCountry = productionCountry;
           
        }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductionID { get; set; }
        public string ProductionName { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorLastName { get; set; }
        public string ProductionCity { get; set; }
        public string ProductionState { get; set; }
        public string ProductionCountry { get; set; }
        [Key]
        [Column(Order = 2)]
        public Guid TheaterID { get; set; }
        public Theater theater { get; set; }

        public virtual ICollection<ProductionHelp> ProductionHelps { get; set; }
    }
}

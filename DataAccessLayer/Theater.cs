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
   public class Theater
    {
        [Key]
        public int TheaterID { get; set; }

        // TODO: Incomplete Entity - Must finish adding other properties

        // This is a collection navigation property
       // public ICollection<Production> Production { get; set; }

        
    }
}

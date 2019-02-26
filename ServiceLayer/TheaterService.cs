using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class TheaterService
    {
        private readonly BroadwayBuiderContext _dbContext;

        public TheaterService(BroadwayBuilderContext context)
        {
            this._dbContext = context;
        }
        
        public void CreateTheater(Theater theater)
        {

        }
    }
}
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
        private readonly BroadwayBuilderContext _dbContext;

        public TheaterService(BroadwayBuilderContext context)
        {
            this._dbContext = context;
        }

        public void CreateTheater(Theater theater)
        {
            theater.DateCreated = DateTime.Now;
            _dbContext.Theaters.Add(theater);
        }
        public void DeleteTheater(Theater theater)
        {
            Theater theaterToDelete = _dbContext.Theaters.Find(theater.TheaterID);

            if (theaterToDelete != null)
            {
                _dbContext.Theaters.Remove(theaterToDelete);
            }
        }
    }
}
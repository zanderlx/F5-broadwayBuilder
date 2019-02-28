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
            _dbContext.Theaters.Add(theater);
        }

        public Theater GetTheaterByID(Guid theaterID)
        {
            return _dbContext.Theaters.Find(theaterID);
        }

        public Theater GetTheaterByName(string theaterName)
        {
            return _dbContext.Theaters.Find(theaterName);
        }

        public Theater UpdateTheater(Theater theater)
        {
            Theater theaterToUpdate = GetTheaterByID(theater.TheaterID);
            if (theaterToUpdate != null)
            {
                theaterToUpdate = theater;
                return theaterToUpdate;
            }
            return null;
        }

        public Theater DeleteTheater(Theater theater)
        {
            Theater deletedTheater = _dbContext.Theaters.Remove(theater);
            return deletedTheater;
        }
    }
}
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
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

        public Theater GetTheaterByID(int theaterID)
        {
            return _dbContext.Theaters.Find(theaterID);
        }

        //public Theater GetTheaterByName(string theaterName)
        //{
        //    return _dbContext.Theaters.Find(theaterName);
        //}

        public Theater UpdateTheater(Theater theater)
        {
            Theater theaterToUpdate = _dbContext.Theaters.Find(theater.TheaterID);

            if (theaterToUpdate != null)
            {
                theaterToUpdate.TheaterName = theater.TheaterName;
                theaterToUpdate.CompanyName = theater.CompanyName;
                theaterToUpdate.StreetAddress = theater.StreetAddress;
                theaterToUpdate.City = theater.City;
                theaterToUpdate.State = theater.State;
                theaterToUpdate.Country = theater.Country;
                theaterToUpdate.PhoneNumber = theater.PhoneNumber;
            }
            return theaterToUpdate;
        }

        public void DeleteTheater(Theater theater)
        {
            Theater theaterToDelete = _dbContext.Theaters.Find(theater.TheaterID);

            if (theaterToDelete != null)
            {
                _dbContext.Theaters.Remove(theaterToDelete);
            }
        }

        public Theater DeleteTheaterAgain(Theater theater)
        {
            Theater deletedTheater = _dbContext.Theaters.Remove(theater);
            return deletedTheater;
        }
    }
}
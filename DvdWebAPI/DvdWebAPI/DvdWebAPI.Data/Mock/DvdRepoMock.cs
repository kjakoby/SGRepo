using DvdWebAPI.Data.Interfaces;
using DvdWebAPI.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdWebAPI.Data.Mock
{
    public class DvdRepoMock : IDvdRepo
    {
        public DvdDetails Delete(int dvdID)
        {
            return MockRepo.Delete(dvdID);
        }

        public List<DvdDetails> GetAll()
        {
            return MockRepo.GetAll();
        }

        public List<DvdDetails> GetByDirector(string director)
        {
            return MockRepo.GetByDirector(director);
        }

        public DvdDetails GetByID(int DvdID)
        {
            return MockRepo.GetByID(DvdID);
        }

        public List<DvdDetails> GetByRating(string rating)
        {
            return MockRepo.GetByRating(rating);
        }

        public List<DvdDetails> GetByTitle(string title)
        {
            return MockRepo.GetByTitle(title);
        }

        public List<DvdDetails> GetByYear(int year)
        {
            return MockRepo.GetByYear(year.ToString());
        }

        public DvdDetails Insert(DvdDetails dvd)
        {
            return MockRepo.Insert(dvd);
        }

        public DvdDetails Update(DvdDetails dvd)
        {
            return MockRepo.Update(dvd);
        }
    }
}

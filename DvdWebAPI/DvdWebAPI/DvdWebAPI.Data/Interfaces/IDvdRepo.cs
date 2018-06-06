using DvdWebAPI.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdWebAPI.Data.Interfaces
{
    public interface IDvdRepo
    {
        List<DvdDetails> GetAll();
        DvdDetails GetByID(int DvdID);
        List<DvdDetails> GetByDirector(string director);
        List<DvdDetails> GetByTitle(string title);
        List<DvdDetails> GetByYear(int year);
        List<DvdDetails> GetByRating(string rating);
        DvdDetails Insert(DvdDetails dvd);
        DvdDetails Update(DvdDetails dvd);
        DvdDetails Delete(int dvdID);
    }
}


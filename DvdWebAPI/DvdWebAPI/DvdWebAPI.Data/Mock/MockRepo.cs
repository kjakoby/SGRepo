using DvdWebAPI.Models.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdWebAPI.Data.Mock
{
    public class MockRepo
    {
        private static List<DvdDetails> _dvds = new List<DvdDetails>
        {
            new DvdDetails
            {DvdID=1, Title="BeetleBorgs", Year=1996, DirectorName= "Jeff Burr", RatingValue="PG", Note="Similar to Power Rangers, but wayyy more interesting!", DirectorID=1, RatingID=1, ReleaseID=1},
            new DvdDetails
            {DvdID=2, Title="Pacific Rim", Year=2013, DirectorName= "Guillermo Del Toro", RatingValue="PG-13", Note="Action packed, giant robot vs. monster battle!", DirectorID=2, RatingID=2, ReleaseID=2},
            new DvdDetails
            {DvdID=3, Title="HellBoy", Year=2004, DirectorName= "Guillermo Del Toro", RatingValue="PG-13", Note="Who knew a devil like creature would be a good guy!", DirectorID=2, RatingID=2, ReleaseID=3},
            new DvdDetails
            {DvdID=4, Title="Ready Player One", Year=2018, DirectorName= "Steven Spielberg", RatingValue="PG-13", Note="A VR based world as the trophy for the biggest contest ever!", DirectorID=2, RatingID=1, ReleaseID=4}
        };

        public static List<DvdDetails> GetAll()
        {
            return _dvds;
        }

        public static DvdDetails GetByID(int dvdId)
        {
            if (_dvds.Where(d=>d.DvdID==dvdId).Count() == 0)
            {
                return null;
            }
            else
            {
                return _dvds.FirstOrDefault(d => d.DvdID == dvdId);
            }
        }

        public static DvdDetails Insert(DvdDetails dvd)
        {
            if (_dvds.Count()==0)
            {
                dvd.DvdID = 1;
            }
            else
            {
                dvd.DvdID = _dvds.Max(d => d.DvdID) + 1;
            }
            _dvds.Add(dvd);

            return dvd;
        }

        public static DvdDetails Update(DvdDetails dvd)
        {
            var found = _dvds.FirstOrDefault(d => d.DvdID == dvd.DvdID);

            if (found != null)
            {
                //found = dvd;
                return dvd;
            }
            else
            {
                return null;
            }
        }

        public static DvdDetails Delete(int dvdId)
        {
            DvdDetails dvdToDelete = _dvds.Where(d => d.DvdID == dvdId).FirstOrDefault();
            if (dvdToDelete == null)
            {
                return null;
            }
            else
            {
                _dvds.RemoveAll(d => d.DvdID == dvdId);
                return dvdToDelete;
            }
            
        }

        public static List<DvdDetails> GetByTitle(string title)
        {
            var dvds = _dvds.Where(d => (d.Title.ToLower()).Contains(title.ToLower())).ToList();

            //var dvds = _dvds.Where(d => d.title==title).ToList();

            return dvds;
            //return _dvds.Where(d => d.title.Contains(title)).ToList();
        }

        public static List<DvdDetails> GetByYear(string year)
        {
            var dvds = _dvds.Where(d => d.Year.ToString().Contains(year)).ToList();

            return dvds;
        }

        public static List<DvdDetails> GetByDirector(string directorName)
        {
            var dvds = _dvds.Where(d => (d.DirectorName.ToLower()).Contains(directorName.ToLower())).ToList();

            //var dvds = _dvds.Where(d => d.title==title).ToList();

            return dvds;
            //return _dvds.Where(d => d.title.Contains(title)).ToList();
        }

        public static List<DvdDetails> GetByRating(string rating)
        {
            var dvds = _dvds.Where(d => (d.RatingValue.ToLower()).Contains(rating.ToLower())).ToList();

            //var dvds = _dvds.Where(d => d.title==title).ToList();

            return dvds;
            //return _dvds.Where(d => d.title.Contains(title)).ToList();
        }
    }
}

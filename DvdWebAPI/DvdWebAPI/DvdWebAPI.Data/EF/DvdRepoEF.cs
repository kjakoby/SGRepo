using DvdWebAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdWebAPI.Models.Queries;
using System.Data.SqlClient;
using System.Data;

namespace DvdWebAPI.Data.EF
{
    public class DvdRepoEF : IDvdRepo
    {
        public DvdDetails Delete(int dvdID)
        {
            DvdDetails dvdToDelete = this.GetByID(dvdID);
            using (var context = new DvdContextModel())
            {
                var idParamter = new SqlParameter
                { ParameterName = "@DvdID", SqlDbType = SqlDbType.Int, Value = dvdID };

                context.Database.SqlQuery<DvdDetails>("DvdDelete @DvdID", idParamter).SingleOrDefault();
            }

            return dvdToDelete;
        }

        public List<DvdDetails> GetAll()
        {
            List<DvdDetails> dvdList = new List<DvdDetails>();
            using (var context = new DvdContextModel())
            {
                List<DvdDetails> dvdsFound = context.Database.SqlQuery<DvdDetails>("AllDvdsDetails").ToList();
                foreach (DvdDetails dvd in dvdsFound)
                {
                    dvdList.Add(dvd);
                }
            }

            return dvdList;
        }

        public List<DvdDetails> GetByDirector(string director)
        {
            List<DvdDetails> dvdList = new List<DvdDetails>();
            using (var context = new DvdContextModel())
            {
                var idParameter = new SqlParameter
                { ParameterName = "@DirectorName", SqlDbType = SqlDbType.VarChar, Value = director };

                List<DvdDetails> dvdsFound = context.Database.SqlQuery<DvdDetails>("DvdDetailsByDirector @DirectorName", idParameter).ToList();
                foreach (DvdDetails dvd in dvdsFound)
                {
                    dvdList.Add(dvd);
                }
            }

            return dvdList;
        }

        public DvdDetails GetByID(int DvdID)
        {
            DvdDetails dvd = new DvdDetails();
            using (var context = new DvdContextModel())
            {
                var idParameter = new SqlParameter
                { ParameterName = "@DvdID", SqlDbType = SqlDbType.Int, Value=DvdID};

                dvd = context.Database.SqlQuery<DvdDetails>("DvdDetailsByID @DvdID", idParameter).SingleOrDefault();
            }

            return dvd;
        }

        public List<DvdDetails> GetByRating(string rating)
        {
            List<DvdDetails> dvdList = new List<DvdDetails>();
            using (var context = new DvdContextModel())
            {
                var idParameter = new SqlParameter
                { ParameterName = "@RatingValue", SqlDbType = SqlDbType.VarChar, Value = rating };

                List<DvdDetails> dvdsFound = context.Database.SqlQuery<DvdDetails>("DvdDetailsByRating @RatingValue", idParameter).ToList();
                foreach (DvdDetails dvd in dvdsFound)
                {
                    dvdList.Add(dvd);
                }
            }

            return dvdList;
        }

        public List<DvdDetails> GetByTitle(string title)
        {
            List<DvdDetails> dvdList = new List<DvdDetails>();
            using (var context = new DvdContextModel())
            {
                var idParameter = new SqlParameter
                { ParameterName = "@Title", SqlDbType = SqlDbType.VarChar, Value = title };

                List<DvdDetails> dvdsFound = context.Database.SqlQuery<DvdDetails>("DvdDetailsByTitle @Title", idParameter).ToList();
                foreach (DvdDetails dvd in dvdsFound)
                {
                    dvdList.Add(dvd);
                }
            }

            return dvdList;
        }

        public List<DvdDetails> GetByYear(int year)
        {
            List<DvdDetails> dvdList = new List<DvdDetails>();
            using (var context = new DvdContextModel())
            {
                var idParameter = new SqlParameter
                { ParameterName = "@Year", SqlDbType = SqlDbType.VarChar, Value = year };

                List<DvdDetails> dvdsFound = context.Database.SqlQuery<DvdDetails>("DvdDetailsByReleaseYear @Year", idParameter).ToList();
                foreach (DvdDetails dvd in dvdsFound)
                {
                    dvdList.Add(dvd);
                }
            }

            return dvdList;
        }

        public DvdDetails Insert(DvdDetails dvd)
        {
            using (var context = new DvdContextModel())
            {
                var idParameter = new SqlParameter
                { ParameterName = "@DvdID", SqlDbType = SqlDbType.Int, Value = 0, Direction = ParameterDirection.Output };
                var titleParameter = new SqlParameter
                { ParameterName = "@Title", SqlDbType = SqlDbType.VarChar, Value = dvd.Title };
                var yearParameter = new SqlParameter
                { ParameterName = "@Year", SqlDbType = SqlDbType.Int, Value = dvd.Year };
                var directorParameter = new SqlParameter
                { ParameterName = "@DirectorName", SqlDbType = SqlDbType.VarChar, Value = dvd.DirectorName };
                var ratingParameter = new SqlParameter
                { ParameterName = "@RatingValue", SqlDbType = SqlDbType.VarChar, Value = dvd.RatingValue };
                var noteParameter = new SqlParameter
                { ParameterName = "@Note", SqlDbType = SqlDbType.VarChar, Value = dvd.Note };

                context.Database.SqlQuery<DvdDetails>("DvdInsert @DvdID OUTPUT, @Title, @Year, @DirectorName, @RatingValue, @Note", idParameter, titleParameter, yearParameter, directorParameter, ratingParameter, noteParameter).SingleOrDefault();

                dvd.DvdID = (int)idParameter.Value;
            }

            return dvd;
        }

        public DvdDetails Update(DvdDetails dvd)
        {
            using (var context = new DvdContextModel())
            {
                var idParameter = new SqlParameter
                { ParameterName = "@DvdID", SqlDbType = SqlDbType.Int, Value = dvd.DvdID };
                var titleParameter = new SqlParameter
                { ParameterName = "@Title", SqlDbType = SqlDbType.VarChar, Value = dvd.Title };
                var yearParameter = new SqlParameter
                { ParameterName = "@Year", SqlDbType = SqlDbType.Int, Value = dvd.Year };
                var directorParameter = new SqlParameter
                { ParameterName = "@DirectorName", SqlDbType = SqlDbType.VarChar, Value = dvd.DirectorName };
                var ratingParameter = new SqlParameter
                { ParameterName = "@RatingValue", SqlDbType = SqlDbType.VarChar, Value = dvd.RatingValue };
                var noteParameter = new SqlParameter
                { ParameterName = "@Note", SqlDbType = SqlDbType.VarChar, Value = dvd.Note };

                context.Database.SqlQuery<DvdDetails>("DvdUpdate @DvdID, @Title, @Year, @DirectorName, @RatingValue, @Note", idParameter, titleParameter, yearParameter, directorParameter, ratingParameter, noteParameter).SingleOrDefault();
            }

            return dvd;
        }
    }
}

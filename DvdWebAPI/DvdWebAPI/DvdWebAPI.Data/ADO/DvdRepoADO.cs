using DvdWebAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdWebAPI.Models.Queries;
using System.Data.SqlClient;
using System.Data;

namespace DvdWebAPI.Data.ADO
{
    public class DvdRepoADO : IDvdRepo
    {
        public DvdDetails Delete(int dvdID)
        {
            DvdDetails dvdDeleted = this.GetByID(dvdID);

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdID", dvdID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }

            return dvdDeleted;
        }

        public List<DvdDetails> GetAll()
        {
            List<DvdDetails> dvds = new List<DvdDetails>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AllDvdsDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DvdDetails currentRow = new DvdDetails();
                        currentRow.DvdID = (int)dr["DvdID"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.DirectorID = (int)dr["DirectorID"];
                        currentRow.RatingID = (int)dr["RatingID"];
                        currentRow.ReleaseID = (int)dr["ReleaseID"];
                        currentRow.DirectorName = dr["DirectorName"].ToString();
                        currentRow.RatingValue = dr["RatingValue"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        if (dr["Note"] != DBNull.Value)
                        {
                            currentRow.Note = dr["Note"].ToString();
                        }

                        dvds.Add(currentRow);
                    }
                }
            }

            return dvds;
        }

        public List<DvdDetails> GetByDirector(string director)
        {
            List<DvdDetails> dvds = new List<DvdDetails>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdDetailsByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DirectorName", director);
                cn.Open();

                //SELECT DvdID, Title, ReleaseID, DirectorID, RatingID, Note
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DvdDetails currentRow = new DvdDetails();
                        currentRow.DvdID = (int)dr["DvdID"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseID = (int)dr["ReleaseID"];
                        currentRow.DirectorID = (int)dr["DirectorID"];
                        currentRow.RatingID = (int)dr["RatingID"];
                        currentRow.DirectorName = dr["DirectorName"].ToString();
                        currentRow.RatingValue = dr["RatingValue"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        if (dr["Note"] != DBNull.Value)
                        {
                            currentRow.Note = dr["Note"].ToString();
                        }

                        dvds.Add(currentRow);
                    }
                }
            }

            return dvds;
        }

        public DvdDetails GetByID(int DvdID)
        {
            DvdDetails dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdDetailsByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdID", DvdID);
                cn.Open();

                //SELECT DvdID, Title, ReleaseID, DirectorID, RatingID, Note
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new DvdDetails();
                        dvd.DvdID = (int)dr["DvdID"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseID = (int)dr["ReleaseID"];
                        dvd.DirectorID = (int)dr["DirectorID"];
                        dvd.RatingID = (int)dr["RatingID"];
                        dvd.DirectorName = dr["DirectorName"].ToString();
                        dvd.RatingValue = dr["RatingValue"].ToString();
                        dvd.Year = (int)dr["Year"];
                        if (dr["Note"] != DBNull.Value)
                        {
                            dvd.Note = dr["Note"].ToString();
                        }
                    }
                }
            }

            return dvd;
        }

        public List<DvdDetails> GetByRating(string rating)
        {
            List<DvdDetails> dvds = new List<DvdDetails>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdDetailsByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RatingValue", rating);
                cn.Open();

                //SELECT DvdID, Title, ReleaseID, DirectorID, RatingID, Note
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DvdDetails currentRow = new DvdDetails();
                        currentRow.DvdID = (int)dr["DvdID"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseID = (int)dr["ReleaseID"];
                        currentRow.DirectorID = (int)dr["DirectorID"];
                        currentRow.RatingID = (int)dr["RatingID"];
                        currentRow.DirectorName = dr["DirectorName"].ToString();
                        currentRow.RatingValue = dr["RatingValue"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        if (dr["Note"] != DBNull.Value)
                        {
                            currentRow.Note = dr["Note"].ToString();
                        }

                        dvds.Add(currentRow);
                    }
                }
            }

            return dvds;
        }

        public List<DvdDetails> GetByTitle(string title)
        {
            List<DvdDetails> dvds = new List<DvdDetails>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdDetailsByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", title);
                cn.Open();

                //SELECT DvdID, Title, ReleaseID, DirectorID, RatingID, Note
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DvdDetails currentRow = new DvdDetails();
                        currentRow.DvdID = (int)dr["DvdID"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseID = (int)dr["ReleaseID"];
                        currentRow.DirectorID = (int)dr["DirectorID"];
                        currentRow.RatingID = (int)dr["RatingID"];
                        currentRow.DirectorName = dr["DirectorName"].ToString();
                        currentRow.RatingValue = dr["RatingValue"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        if (dr["Note"] != DBNull.Value)
                        {
                            currentRow.Note = dr["Note"].ToString();
                        }

                        dvds.Add(currentRow);
                    }
                }
            }

            return dvds;
        }

        public List<DvdDetails> GetByYear(int year)
        {
            List<DvdDetails> dvds = new List<DvdDetails>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdDetailsByReleaseYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReleaseYear", year);
                cn.Open();

                //SELECT DvdID, Title, ReleaseID, DirectorID, RatingID, Note
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DvdDetails currentRow = new DvdDetails();
                        currentRow.DvdID = (int)dr["DvdID"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseID = (int)dr["ReleaseID"];
                        currentRow.DirectorID = (int)dr["DirectorID"];
                        currentRow.RatingID = (int)dr["RatingID"];
                        currentRow.DirectorName = dr["DirectorName"].ToString();
                        currentRow.RatingValue = dr["RatingValue"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        if (dr["Note"] != DBNull.Value)
                        {
                            currentRow.Note = dr["Note"].ToString();
                        }

                        dvds.Add(currentRow);
                    }
                }
            }

            return dvds;
        }

        public DvdDetails Insert(DvdDetails dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DvdID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Year", dvd.Year);
                cmd.Parameters.AddWithValue("@RatingValue", dvd.RatingValue);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@NoteInfo", dvd.Note);
                //cmd.Parameters.AddWithValue("@ReleaseID", dvd.ReleaseID);
                //cmd.Parameters.AddWithValue("@RatingID", dvd.RatingID);
                //cmd.Parameters.AddWithValue("@DirectorID", dvd.DirectorID);

                cn.Open();
                cmd.ExecuteNonQuery();

                dvd.DvdID = (int)param.Value;
            }

            return dvd;
        }

        public DvdDetails Update(DvdDetails dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdID", dvd.DvdID);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Year", dvd.Year);
                cmd.Parameters.AddWithValue("@RatingValue", dvd.RatingValue);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@NoteInfo", dvd.Note);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            return dvd;
        }
    }
}

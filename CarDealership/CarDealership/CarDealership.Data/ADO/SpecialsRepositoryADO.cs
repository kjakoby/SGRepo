using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;
using System.Data.SqlClient;
using System.Data;
using CarDealership.Models.Queries;

namespace CarDealership.Data.ADO
{
    public class SpecialsRepositoryADO : ISpecialsRepository
    {
        public void Delete(int specialID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialID", specialID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Specials> GetAll()
        {
            List<Specials> specials = new List<Specials>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentRow = new Specials();
                        currentRow.SpecialID = (int)dr["SpecialID"];
                        currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();

                        specials.Add(currentRow);
                    }
                }
            }

            return specials;
        }

        public void Insert(Specials special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@SpecialTitle", special.SpecialTitle);
                cmd.Parameters.AddWithValue("@SpecialDescription", special.SpecialDescription);

                cn.Open();

                cmd.ExecuteNonQuery();

                special.SpecialID = (int)param.Value;
            }
        }

        public Specials GetByID(int specialID)
        {
            Specials special = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SingleSpecial", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialID", specialID);
                cn.Open();

                //SELECT VehicleID, [Year], Mileage, MSRP, SalesPrice, [Description], Picture, Featured, VIN, UserID, ModelID, ColorID, TypeID, TransmissionID, InteriorID 
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        special = new Specials();
                        special.SpecialID = (int)dr["SpecialID"];
                        special.SpecialTitle = dr["SpecialTitle"].ToString();
                        special.SpecialDescription = dr["SpecialDescription"].ToString();
                        
                    }
                }
            }

            return special;
        }

        public IEnumerable<SpecialsItem> GetList()
        {
            List<SpecialsItem> specials = new List<SpecialsItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SpecialsItem currentRow = new SpecialsItem();
                        currentRow.SpecialID = (int)dr["SpecialID"];
                        currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();

                        specials.Add(currentRow);
                    }
                }
            }

            return specials;
        }
    }
}

using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Tables;
using System.Data.SqlClient;
using System.Data;

namespace CarDealership.Data.ADO
{
    public class InteriorRepositoryADO : IInteriorRepository
    {
        public List<Interior> GetAll()
        {
            List<Interior> interiors = new List<Interior>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Interior currentRow = new Interior();
                        currentRow.InteriorID = (int)dr["InteriorID"];
                        currentRow.InteriorColor = dr["InteriorColor"].ToString();

                        interiors.Add(currentRow);
                    }
                }
            }

            return interiors;
        }
    }
}

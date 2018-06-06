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
    public class TypeRepositoryADO : ITypeRepository
    {
        public List<Models.Tables.Type> GetAll()
        {
            List<Models.Tables.Type> types = new List<Models.Tables.Type>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TypeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Models.Tables.Type currentRow = new Models.Tables.Type();
                        currentRow.TypeID = (int)dr["TypeID"];
                        currentRow.TypeName = dr["TypeName"].ToString();

                        types.Add(currentRow);
                    }
                }
            }

            return types;
        }
    }
}

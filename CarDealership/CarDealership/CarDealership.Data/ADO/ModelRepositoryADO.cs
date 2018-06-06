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
    public class ModelRepositoryADO : IModelRepository
    {
        public List<Model> GetAll()
        {
            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelDateAdded = (DateTime)dr["ModelDateAdded"];
                        models.Add(currentRow);
                    }
                }
            }

            return models;
        }

        public void Insert(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeID", model.MakeID);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@ModelDateAdded", DateTime.Today);
                cmd.Parameters.AddWithValue("@UserID", model.UserID);

                cn.Open();

                cmd.ExecuteNonQuery();

                model.ModelID = (int)param.Value;
            }
        }

        public IEnumerable<ModelItem> GetModels()
        {
            List<ModelItem> models = new List<ModelItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelList", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ModelItem currentRow = new ModelItem();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelDateAdded = (DateTime)dr["ModelDateAdded"];
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.UserID = dr["UserID"].ToString();

                        models.Add(currentRow);
                    }
                }
            }

            return models;
        }
    }
}

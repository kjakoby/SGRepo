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
    public class PurchaseRepositoryADO : IPurchaseRepository
    {
        public List<Purchase> GetAll()
        {
            List<Purchase> purchases = new List<Purchase>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Purchase currentRow = new Purchase();
                        currentRow.PurchaseID = (int)dr["PurchaseID"];
                        currentRow.SellName = dr["SellName"].ToString();
                        currentRow.SellPhone = dr["SellPhone"].ToString();
                        currentRow.SellEmail = dr["SellEmail"].ToString();
                        currentRow.SellStreet1 = dr["SellStreet1"].ToString();
                        currentRow.SellStreet2 = dr["SellStreet2"].ToString();
                        currentRow.City = dr["City"].ToString();
                        currentRow.State = dr["State"].ToString();
                        currentRow.ZipCode = (int)dr["ZipCode"];
                        currentRow.PurchasePrice = (int)dr["PurchasePrice"];
                        currentRow.PurchaseTypeID = (int)dr["PurchaseTypeID"];
                        currentRow.UserID = dr["UserID"].ToString();
                        currentRow.VehicleID = (int)dr["VehicleID"];

                        purchases.Add(currentRow);
                    }
                }
            }

            return purchases;
        }

        public void Insert(Purchase purchase)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@PurchaseID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@SellName", purchase.SellName);
                cmd.Parameters.AddWithValue("@SellPhone", purchase.SellPhone);
                cmd.Parameters.AddWithValue("@SellEmail", purchase.SellEmail);
                cmd.Parameters.AddWithValue("@SellStreet1", purchase.SellStreet1);
                cmd.Parameters.AddWithValue("@SellStreet2", purchase.SellStreet2);
                cmd.Parameters.AddWithValue("@City", purchase.City);
                cmd.Parameters.AddWithValue("@State", purchase.State);
                cmd.Parameters.AddWithValue("@ZipCode", purchase.ZipCode);
                cmd.Parameters.AddWithValue("@PurchasePrice", purchase.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseTypeID", purchase.PurchaseTypeID);
                cmd.Parameters.AddWithValue("@VehicleID", purchase.VehicleID);
                cmd.Parameters.AddWithValue("@UserID", purchase.UserID);

                cn.Open();

                cmd.ExecuteNonQuery();

                purchase.PurchaseID = (int)param.Value;
            }
        }
    }
}

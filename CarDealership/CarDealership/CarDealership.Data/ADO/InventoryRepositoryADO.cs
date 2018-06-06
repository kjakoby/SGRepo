using CarDealership.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models.Queries;
using System.Data.SqlClient;
using System.Data;

namespace CarDealership.Data.ADO
{
    public class InventoryRepositoryADO : IInventoryRepository
    {
        public IEnumerable<InventoryReportItem> GetNewInventory()
        {
            List<InventoryReportItem> newList = new List<InventoryReportItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("NewInventory", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReportItem currentRow = new InventoryReportItem();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (int)dr["StockValue"];

                        newList.Add(currentRow);
                    }
                }
            }

            return newList;
        }

        public IEnumerable<InventoryReportItem> GetUsedInventory()
        {
            List<InventoryReportItem> usedList = new List<InventoryReportItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UsedInventory", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReportItem currentRow = new InventoryReportItem();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (int)dr["StockValue"];

                        usedList.Add(currentRow);
                    }
                }
            }

            return usedList;
        }
    }
}

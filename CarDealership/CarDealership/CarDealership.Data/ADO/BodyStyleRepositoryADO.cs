﻿using CarDealership.Data.Interfaces;
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
    public class BodyStyleRepositoryADO : IBodyStyleRepository
    {
        public List<BodyStyle> GetAll()
        {
            List<BodyStyle> bodyStyles = new List<BodyStyle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStyleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle currentRow = new BodyStyle();
                        currentRow.BodyID = (int)dr["BodyID"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();

                        bodyStyles.Add(currentRow);
                    }
                }
            }

            return bodyStyles;
        }
    }
}

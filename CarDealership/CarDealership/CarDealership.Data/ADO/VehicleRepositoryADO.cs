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
    public class VehicleRepositoryADO : IVehicleRepository
    {
        public void Delete(int vehicleID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.VehicleID = (int)dr["VehicleID"];
                        currentRow.Year = (int)dr["Year"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.MSRP = (int)dr["MSRP"];
                        currentRow.SalesPrice = (int)dr["SalesPrice"];
                        currentRow.Description = dr["Description"].ToString();
                        currentRow.Picture = dr["Picture"].ToString();
                        currentRow.Featured = (bool)dr["Featured"];
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.UserID = dr["UserID"].ToString();
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.ColorID = (int)dr["ColorID"];
                        currentRow.TypeID = (int)dr["TypeID"];
                        currentRow.TransmissionID = (int)dr["TransmissionID"];
                        currentRow.InteriorID = (int)dr["InteriorID"];

                        vehicles.Add(currentRow);
                    }
                }
            }

            return vehicles;
        }

        public Vehicle GetByID(int vehicleID)
        {
            Vehicle vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SingleVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                cn.Open();

                //SELECT VehicleID, [Year], Mileage, MSRP, SalesPrice, [Description], Picture, Featured, VIN, UserID, ModelID, ColorID, TypeID, TransmissionID, InteriorID 
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.Year = (int)dr["Year"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.MSRP = (int)dr["MSRP"];
                        vehicle.SalesPrice = (int)dr["SalesPrice"];
                        vehicle.Description = dr["Description"].ToString();
                        if (dr["Picture"] != DBNull.Value)
                        {
                            vehicle.Picture = dr["Picture"].ToString();
                        }
                        vehicle.Featured = (bool)dr["Featured"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.UserID = dr["UserID"].ToString();
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.ColorID = (int)dr["ColorID"];
                        vehicle.TypeID = (int)dr["TypeID"];
                        vehicle.TransmissionID = (int)dr["TransmissionID"];
                        vehicle.InteriorID = (int)dr["InteriorID"];
                        vehicle.BodyID = (int)dr["BodyID"];
                    }
                }
            }

            return vehicle;
        }

        public VehicleDetailsItem GetDetails(int vehicleID)
        {
            VehicleDetailsItem vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                cn.Open();

                //SELECT VehicleID, [Year], Mileage, MSRP, SalesPrice, [Description], Picture, Featured, VIN, UserID, ModelID, ColorID, TypeID, TransmissionID, InteriorID 
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new VehicleDetailsItem();
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.MakeID = (int)dr["MakeID"];
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.MSRP = (int)dr["MSRP"];
                        vehicle.SalesPrice = (int)dr["SalesPrice"];
                        vehicle.Description = dr["Description"].ToString();
                        if (dr["Picture"] != DBNull.Value)
                        {
                            vehicle.Picture = dr["Picture"].ToString();
                        }
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.ColorID = (int)dr["ColorID"];
                        vehicle.TransmissionID = (int)dr["TransmissionID"];
                        vehicle.InteriorID = (int)dr["InteriorID"];
                        vehicle.BodyID = (int)dr["BodyID"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.Year = (int)dr["Year"];
                        vehicle.BodyStyleName = dr["BodyStyleName"].ToString();
                        vehicle.InteriorColor = dr["InteriorColor"].ToString();
                        vehicle.TransmissionType = dr["TransmissionType"].ToString();
                        vehicle.ColorName = dr["ColorName"].ToString();
                    }
                }
            }

            return vehicle;
        }

        public IEnumerable<FeaturedItem> GetFeatured()
        {
            List<FeaturedItem> featured = new List<FeaturedItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AllFeaturedVehiclesShort", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                //SELECT VehicleID, [Year], Mileage, MSRP, SalesPrice, [Description], Picture, Featured, VIN, UserID, ModelID, ColorID, TypeID, TransmissionID, InteriorID 
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedItem row = new FeaturedItem();

                        row.VehicleID = (int)dr["VehicleID"];
                        //row.MakeID = (int)dr["MakeID"];
                        //row.ModelID = (int)dr["ModelID"];
                        row.Year = (int)dr["Year"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        row.SalesPrice = (int)dr["SalesPrice"];
                        if (dr["Picture"] != DBNull.Value)
                        {
                            row.Picture = dr["Picture"].ToString();
                        }

                        featured.Add(row);
                    }
                }
            }

            return featured;
        }

        public void Insert(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Picture", vehicle.Picture);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                //cmd.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@BodyID", vehicle.BodyID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@ColorID", vehicle.ColorID);
                cmd.Parameters.AddWithValue("@TypeID", vehicle.TypeID);
                cmd.Parameters.AddWithValue("@UserID", vehicle.UserID);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.TransmissionID);
                cmd.Parameters.AddWithValue("@InteriorID", vehicle.InteriorID);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleID = (int)param.Value;
            }
        }

        public void Update(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Picture", vehicle.Picture);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                //cmd.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@BodyID", vehicle.BodyID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@ColorID", vehicle.ColorID);
                cmd.Parameters.AddWithValue("@TypeID", vehicle.TypeID);
                cmd.Parameters.AddWithValue("@UserID", vehicle.UserID);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.TransmissionID);
                cmd.Parameters.AddWithValue("@InteriorID", vehicle.InteriorID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}

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
    public class UserRepositoryADO : IUserRepository
    {
        public IEnumerable<UserItem> GetAll()
        {
            List<UserItem> userList = new List<UserItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UserList", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UserItem currentRow = new UserItem();
                        currentRow.UserID = dr["UserID"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Role = dr["Role"].ToString();

                        userList.Add(currentRow);
                    }
                }
            }

            return userList;
        }
    }
}

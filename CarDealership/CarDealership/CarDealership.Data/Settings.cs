using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class Settings
    {
        private static string _connectionString;
        private static string _repoMode;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }

            return _connectionString;
        }

        public static string GetRepoMode()
        {
            if (string.IsNullOrEmpty(_repoMode))
            {
                _repoMode = ConfigurationManager.AppSettings["Mode"].ToString();
            }

            return _repoMode;
        }
    }
}

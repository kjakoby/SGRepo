using DvdWebAPI.Data.ADO;
using DvdWebAPI.Data.EF;
using DvdWebAPI.Data.Interfaces;
using DvdWebAPI.Data.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdWebAPI.Data.Factories
{
    public class DvdRepoFactory
    {
        public static IDvdRepo GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "SampleData":
                    return new DvdRepoMock();
                case "EntityFramework":
                    return new DvdRepoEF();
                case "ADO":
                    return new DvdRepoADO();
                default:
                    throw new Exception("Not a valid Repo type");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TractorDex.BLL.Data;
using TractorDex.BLL.Models;

namespace TractorDex.BLL
{
    public class TractorManager
    {
        private TractorRepository _myRepo;

        public TractorManager()
        {
            _myRepo = new TractorRepository();
            //_myRepo.SetupRepo();
            _myRepo.SetupFileRepo(); // removed test data setup, will run from file

        }

        public Tractor GetATractorByKey(int key)
        {
            return _myRepo.GetTractor(key);
        }

        public Dictionary<int, Tractor> GetAllTractors()
        {
            var sortedDictionary = _myRepo.GetAllTractors().OrderBy(kv => kv.Key);
            return sortedDictionary.ToDictionary(kv=>kv.Key, kv=>kv.Value);
        }

        public Tractor DeleteTractor(int key)
        {
            return _myRepo.DeleteTractor(key);
        }

        public bool AddTractor(Tractor newTractor)
        {
            return _myRepo.AddTractor(newTractor);
        }

        public Tractor UpdateTractor(int key, Tractor updatedTractor)
        {
            return _myRepo.UpdateTractor(key, updatedTractor);
        }

        public void CloseManager()
        {
            _myRepo.CloseRepo();
        }
    }
}

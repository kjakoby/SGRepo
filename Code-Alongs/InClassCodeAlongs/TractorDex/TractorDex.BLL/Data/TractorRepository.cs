using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TractorDex.BLL.Models;

namespace TractorDex.BLL.Data
{
    public class TractorRepository
    {
        private Dictionary<int, Tractor> _tractorIndex;
        private const string repoFile = @"D:\SoftwareGuild\new-kyle-jakoby-individual-work\Data\TractorDex\TractorDex.csv"; //use a folder i create for this

        public bool AddTractor(Tractor newTractor)
        {
            int newKey;
            if(_tractorIndex.Count>0)
            {
                newKey = _tractorIndex.Keys.Max(i => i) + 1;
            }
            else
            {
                newKey = 1;
            }
            _tractorIndex.Add(newKey, newTractor);
            if (_tractorIndex.ContainsKey(newKey))
                return true;
            else
                return false;
        }

        public Tractor UpdateTractor(Tractor original,Tractor currentTractor)
        {
            int myKey=-1;
            var TractorKeyValue = _tractorIndex.Where(kv => kv.Value.Name == original.Name);
            if(TractorKeyValue.SingleOrDefault().Value != null)
            {
                myKey = TractorKeyValue.SingleOrDefault().Key;
            }

            _tractorIndex[myKey] = currentTractor;
            return _tractorIndex[myKey];
            
        }

        internal void CloseRepo()
        {
            using (StreamWriter writer = new StreamWriter(repoFile))
            {
                foreach (KeyValuePair<int, Tractor> kv in _tractorIndex)
                {
                    if (kv.Value != null)
                    {
                        writer.WriteLine($"{kv.Key}, {kv.Value.Name}, {kv.Value.Driver}, {kv.Value.Weight}");
                    }
                }
                //Comment out above foreach statement and uncomment below text to test if able to write to a file

                //writer.WriteLine("This is a test of the file.");
            }
        }

        public Tractor UpdateTractor(int key, Tractor currentTractor)
        {
            _tractorIndex[key] = currentTractor;
            return _tractorIndex[key];
        }

        public Dictionary<int,Tractor> GetAllTractors()
        {
            return _tractorIndex;
        }

        public Tractor GetTractor(int id)
        {
            if (_tractorIndex.Keys.Contains(id))
            {
                return _tractorIndex[id];
            }
            else
            {
                return null;
            }
            
        }

        public Tractor GetTractorByName(string tractorName)
        {
            return _tractorIndex.Values.SingleOrDefault(t => t.Name == tractorName);
        }

        public Tractor DeleteTractor(int id)
        {
            if (_tractorIndex.ContainsKey(id))
            {
                Tractor removedTractor = _tractorIndex[id];
                _tractorIndex.Remove(id);
                return removedTractor;
            }
            else
                return null;
        }

        public void SetupRepo()
        {
            _tractorIndex = new Dictionary<int, Tractor>();
            _tractorIndex.Add(1, new Tractor()
            {
                Name = "Johnny Reb",
                Driver = "Kenny Webb",
                Weight = 9990
            });
            _tractorIndex.Add(2, new Tractor()
            {
                Name = "Hillbilly Rocket",
                Driver = "Melvin Abbot",
                Weight = 9990
            });
            _tractorIndex.Add(3, new Tractor()
            {
                Name = "Costly Habit",
                Driver = "Dennis Peach",
                Weight = 9800
            });
            _tractorIndex.Add(4, new Tractor()
            {
                Name = "Bullheaded Binder",
                Driver = "Larry Binder",
                Weight = 9990
            });

        }

        public void SetupFileRepo()
        {
            _tractorIndex = new Dictionary<int, Tractor>();
            if (!File.Exists(repoFile))
            {
                File.Create(repoFile);
            }
            else
            {
                //read from file and create tractors.
                using (StreamReader reader = new StreamReader(repoFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        if(values.Length>=4)
                        {

                            //uncomment below text and comment above text out 

                            int key = int.Parse(values[0]);
                            string name = values[1];
                            string driver = values[2];
                            int weight = int.Parse(values[3]);
                            _tractorIndex.Add(key, new Tractor()
                            {
                                Name = name,
                                Driver = driver,
                                Weight = weight
                            });
                        }
                    }
                }
            }
        }
    }
}

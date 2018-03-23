using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.BLL
{
    public class FileAccountRepository : IAccountRepository
    {
        private Dictionary<string, Account> _accountIndex;
        private const string repoFile = @"D:\SoftwareGuild\new-kyle-jakoby-individual-work\Data\SGBank\Accounts.txt";

        public FileAccountRepository()
        {
            _accountIndex = new Dictionary<string, Account>();
            if (!File.Exists(repoFile))
            {
                File.Create(repoFile);
            }
            else
            {
                using (StreamReader reader = new StreamReader(repoFile))
                {
                    reader.ReadLine();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Account account = new Account();
                        string[] values = line.Split(',');
                        if (values.Length == 4)
                        {
                            account.AccountNumber = values[0];
                            account.Name = values[1];
                            account.Balance = int.Parse(values[2]);
                            if (values[3] == "F")
                            {
                                account.Type = AccountType.Free;
                            }
                            if (values[3] == "B")
                            {
                                account.Type = AccountType.Basic;
                            }
                            if (values[3] == "P")
                            {
                                account.Type = AccountType.Premium;
                            }
                            _accountIndex.Add(account.AccountNumber, account);
                        }
                    }
                }
            }
        }

        public Account LoadAccount(string AccountNumber)
        {
            if (_accountIndex.Keys.Contains(AccountNumber))
            {
                return _accountIndex[AccountNumber];
            }
            else
            {
                return null;
            }
        }

        public void SaveAccount(Account account)
        {
            using (StreamWriter writer = new StreamWriter(repoFile))
            {
                writer.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (KeyValuePair<string, Account> kv in _accountIndex)
                {
                    if (kv.Value != null)
                    {
                        writer.WriteLine($"{kv.Key}, {kv.Value.Name}, {kv.Value.Balance},{kv.Value.Type.ToString().First()}");
                    }
                }
            }
        }
    }
}

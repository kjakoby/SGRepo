using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("98765", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("98765", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("98765", "Premium Account", 100, AccountType.Premium, 250, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit depositRule = new NoLimitDepositRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositResponse response = depositRule.Deposit(account, amount);
            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("98765", "Premium Account", 100, AccountType.Free, -100, false)]
        [TestCase("98765", "Premium Account", 100, AccountType.Premium, 100, false)]
        [TestCase("98765", "Premium Account", 150, AccountType.Premium, -700, false)]
        [TestCase("98765", "Premium Account", 500, AccountType.Premium, -400, true)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdrawRule = new PremiumAccountWithdrawRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdrawRule.Withdraw(account, amount);
            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}

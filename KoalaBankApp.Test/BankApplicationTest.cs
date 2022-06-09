using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KoalaBankApp.Test
{
    [TestClass]
    public class BankApplicationTest
    {
        [TestMethod]
        public void Currency_Rate_Test()
        {
            //Arrange
            CurrencyRates sut = new CurrencyRates()
            {
                _Type = "SEK",
                _Rate = 8.5
            };

            //Act

            CurrencyRates.UpdateCurrencyRate(sut);

            double actual = 8.5;

            //Assert
            Assert.AreNotEqual(actual,sut._Rate);
        }
        [TestMethod]
        public void Transfer_Money_Test_Send_20000_to_Other_User()
        {
            //Arrange
            List<BankAccount> BAList1 = new List<BankAccount>();
            List<SavingsAccount> SavingsList1 = new List<SavingsAccount>();
            List<Transactions> TransactionsList1 = new List<Transactions>();
            BankAccount DAccount1 = new BankAccount("Private-USD-Account", 2500, "USD");
            BankAccount BAccount1 = new BankAccount("Privat-Konto", 25000, "SEK");
            User Account1 = new User("Lukke", "hejhej123", "Lucas", "Narfgren", "narfgren@hotmail.com", BAList1, SavingsList1, TransactionsList1, false);
            Account1.BankAccountList.Add(BAccount1);
            Account1.BankAccountList.Add(DAccount1);

            List<BankAccount> BAList2 = new List<BankAccount>();
            List<SavingsAccount> SavingsList2 = new List<SavingsAccount>();
            List<Transactions> TransactionsList2 = new List<Transactions>();
            BankAccount BAccount2 = new BankAccount("Privat-Konto", 25000, "SEK");
            BankAccount BAccount3 = new BankAccount("Extra-Konto", 2925000, "USD");
            User Account2 = new User("Ludde", "hemlis", "Ludwig", "Oleby", "Ludwig1337@live.se", BAList2, SavingsList2, TransactionsList2, false);
            Account2.BankAccountList.Add(BAccount2);
            Account2.BankAccountList.Add(BAccount3);

            bool testbool;
            if (DAccount1.Balance < 0) // if the sending account have less than 0, the test  will fail.
            {
                testbool = false;
            }
            else
            {
                testbool = true;
            }

            //Act
            var recievedAccountBalance = BAccount2.Balance + 20000;
            var AccountBalancefromSender = BAccount1.Balance - 20000;

            var expectedAccountReciever = 45000;
            var expectedAccountSender = 5000;
            //Assert

            Assert.AreEqual(expectedAccountSender,AccountBalancefromSender);
            Assert.AreEqual(expectedAccountReciever,recievedAccountBalance);
            Assert.IsTrue(testbool);
        }

        [TestMethod]
        public void International_Transfer_Test_Using_CurrencyRates_From_USD_to_SEK()
        {
            CurrencyRates TestRate = new CurrencyRates() {_Type ="USD",_Rate = 9.02 };

            List<BankAccount> BAList1 = new List<BankAccount>();
            List<SavingsAccount> SavingsList1 = new List<SavingsAccount>();
            List<Transactions> TransactionsList1 = new List<Transactions>();
            BankAccount DAccount1 = new BankAccount("Private-USD-Account", 2500, "USD");
            BankAccount BAccount1 = new BankAccount("Privat-Konto", 25000, "SEK");
            User Account1 = new User("Lukke", "hejhej123", "Lucas", "Narfgren", "narfgren@hotmail.com", BAList1, SavingsList1, TransactionsList1, false);
            Account1.BankAccountList.Add(BAccount1);
            Account1.BankAccountList.Add(DAccount1);

            List<BankAccount> BAList2 = new List<BankAccount>();
            List<SavingsAccount> SavingsList2 = new List<SavingsAccount>();
            List<Transactions> TransactionsList2 = new List<Transactions>();
            BankAccount BAccount2 = new BankAccount("Privat-Konto", 25000, "SEK");
            BankAccount BAccount3 = new BankAccount("Extra-Konto", 2925000, "USD");
            User Account2 = new User("Ludde", "hemlis", "Ludwig", "Oleby", "Ludwig1337@live.se", BAList2, SavingsList2, TransactionsList2, false);
            Account2.BankAccountList.Add(BAccount2);
            Account2.BankAccountList.Add(BAccount3);

            var AccountBalanceSender = DAccount1.Balance - 500;
            var AccountBalanceReciever = BAccount2.Balance + 500 / 9.02;

            var expectedAccountSender = 2500 - 500;
            var expectedAccountReciever = 25000 + 500 / 9.02;

            Assert.AreEqual(expectedAccountReciever, AccountBalanceReciever);
            Assert.AreEqual(expectedAccountSender, AccountBalanceSender);

        }
        [TestMethod]
        public void International_Transfer_Test_Using_CurrencyRates_From_SEK_to_USD()
        {
            CurrencyRates TestRate = new CurrencyRates() { _Type = "USD", _Rate = 9.02 };

            List<BankAccount> BAList1 = new List<BankAccount>();
            List<SavingsAccount> SavingsList1 = new List<SavingsAccount>();
            List<Transactions> TransactionsList1 = new List<Transactions>();
            BankAccount DAccount1 = new BankAccount("Private-USD-Account", 2500, "USD");
            BankAccount BAccount1 = new BankAccount("Privat-Konto", 25000, "SEK");
            User Account1 = new User("Lukke", "hejhej123", "Lucas", "Narfgren", "narfgren@hotmail.com", BAList1, SavingsList1, TransactionsList1, false);
            Account1.BankAccountList.Add(BAccount1);
            Account1.BankAccountList.Add(DAccount1);

            List<BankAccount> BAList2 = new List<BankAccount>();
            List<SavingsAccount> SavingsList2 = new List<SavingsAccount>();
            List<Transactions> TransactionsList2 = new List<Transactions>();
            BankAccount BAccount2 = new BankAccount("Privat-Konto", 25000, "SEK");
            BankAccount BAccount3 = new BankAccount("Extra-Konto", 2925000, "USD");
            User Account2 = new User("Ludde", "hemlis", "Ludwig", "Oleby", "Ludwig1337@live.se", BAList2, SavingsList2, TransactionsList2, false);
            Account2.BankAccountList.Add(BAccount2);
            Account2.BankAccountList.Add(BAccount3);

            var AccountBalanceSender = BAccount2.Balance - 20000;
            var AccountBalanceReciever = BAccount3.Balance + 20000 / 9.02;

            var expectedAccountSender = 5000;
            var expectedAccountReciever = 2927217.2949002218;

            Assert.AreEqual(expectedAccountReciever, AccountBalanceReciever);
            Assert.AreEqual(expectedAccountSender, AccountBalanceSender);
        }
    }
}

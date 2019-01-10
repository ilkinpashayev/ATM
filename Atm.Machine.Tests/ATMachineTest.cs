using Atm.Machine.Models;
using Atm.Machine.Services;
using NUnit.Framework;

using System.Collections.Generic;

namespace Atm.Machine.Tests
{
    [TestFixture]
    public class ATMachineTest
    {
        [Test]
        public void InsertCard_Inserting_Card_To_Enable_Process_Test()
        {
            //Arrange
            ATMachine pobj = new ATMachine();
            string cardnumber = "5290195567329854";
            //Act
            pobj.InsertCard(cardnumber);
            //Assert
            Assert.AreEqual(ATMStatus.READY, pobj._atmstatus);
        }

        [Test]
        public void GetCardBalance_Getting_Active_Card_Balance_Test()
        {
            //Arrange
            ATMachine objtest = new ATMachine();
            string cardnumber = "5290195567329854";
            //Act
            objtest.InsertCard(cardnumber);
            decimal _result = objtest.GetCardBalance();
            //Assert
            Assert.AreEqual(1000, _result);

        }
        
        [Test]
        public void WithDrawMoney_Check_balance_papernotes_Withdraw_Test()
        {
            //Arrange
            ATMachine objtest = new ATMachine();
            string cardnumber = "5290195567329859";
            
            int amount = 5;

            Money _money;
            //Act
            objtest.InsertCard(cardnumber);

            Money expectedResult = objtest.WithDrawMoney(amount);
            //Assert
            Assert.Greater(expectedResult.Amount, 0);

        }

        
        [Test]

        public void ReturnCard_Return_Card_Test()
        {
            //Arrange
            ATMachine pobj = new ATMachine();
            string cardnumber = "5290195567329859";
            //Act
            pobj.InsertCard(cardnumber);
            pobj.ReturnCard();
            //Assert
            Assert.AreEqual(ATMStatus.READY, pobj._atmstatus);

            
        }
        
        [Test]

        public void LoadMoney_Load_Money_To_ATM_Test()
        {
            //Arrange
            ATMachine pobj = new ATMachine();
            Money _money = new Money();
            _money.Amount = 2000;
            Dictionary<PaperNote, int> _papernote = new Dictionary<PaperNote, int>();
            _papernote.Add(PaperNote.Fifty, 19);
            _papernote.Add(PaperNote.Twenty, 1);
            _papernote.Add(PaperNote.Ten, 2);
            _papernote.Add(PaperNote.Five, 2);
            _money.Notes = _papernote;
            //Act
            pobj.LoadMoney(_money);
            //Assert
            Assert.AreEqual(ATMExecuteStatus.DONE, pobj._atmexecutestatus);
            
        }
        
    }
}

using Atm.Machine.Services;

using NUnit.Framework;

namespace Atm.Machine.Tests
{
    [TestFixture]
    public class CalculateCommission1Test
    {
       

        [Test]
        public void GetCalculatedAmount_CalculatingFeeOnWithdrawTest()
        {
            //Arrange
            CalculateCommission objtest = new CalculateCommission();
            //Act
            decimal _result = objtest.GetCalculatedAmount(2000);
            //Assert
            Assert.AreEqual(20, _result);
           
        }



    }

}

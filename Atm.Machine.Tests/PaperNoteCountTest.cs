using Atm.Machine.Models;
using Atm.Machine.Services;
using Atm.Machine.Services.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm.Machine.Tests
{
    [TestFixture]
    public class PaperNoteCountTest
    {
      [Test]
        public void GetPaperNoteCount_CalculatingandwithdrawingpapernotesTest()
        {
            //Arrange
            PaperNoteCount objtest = new PaperNoteCount();
            Boolean result;
            
            Money _money = new Money();
            Dictionary<PaperNote, int> _dict = new Dictionary<PaperNote, int>();
            int[] notes = new int[] { 50, 20, 10, 5 };
            int[] noteCounter = new int[4];

            //Act

            Money expectedResult = objtest.GetPaperNoteCount(200);

            //Assert
            Assert.Greater( expectedResult.Amount,0);

        }

   }
}

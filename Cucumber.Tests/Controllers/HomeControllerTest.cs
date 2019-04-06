
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cucumber.BLL;

namespace Cucumber.Tests.Controllers
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Zero()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(0);
            Assert.IsTrue("Zero".Equals(output));
        }

        [TestMethod]
        public void Negative()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(-6.25);
            Assert.IsTrue("Negative Six Dollars and Twenty-Five cents".Equals(output));
        }


        [TestMethod]
        public void TensNumber()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(99);
            Assert.IsTrue("Ninety-Nine Dollars".Equals(output));
        }

        [TestMethod]
        public void HundredsNumberLowerlimit()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(100);
            Assert.IsTrue("One Hundred Dollars".Equals(output));
        }

        [TestMethod]
        public void HundredsNumberLowerlimitPlus()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(101);
            Assert.IsTrue("One Hundred and One Dollars".Equals(output));
        }

        [TestMethod]
        public void HundredsNumberUpperLimit()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(999);
            Assert.IsTrue("Nine Hundred and Ninety-Nine Dollars".Equals(output));
        }

        [TestMethod]
        public void ThousandsLowerLimit()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(1000);
            Assert.IsTrue("One Thousand Dollars".Equals(output));
        }

        [TestMethod]
        public void ThousandsUpperLimit()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(999999);
            Assert.IsTrue("Nine Hundred and Ninety-Nine Thousand and Nine Hundred and Ninety-Nine Dollars".Equals(output));
        }

        [TestMethod]
        public void MillionLowerLimit()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(1000000);
            Assert.IsTrue("One Million Dollars".Equals(output));
        }

        [TestMethod]
        public void MillionLowerLimitPlusOne()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(1000001);
            Assert.IsTrue("One Million and One Dollars".Equals(output));
        }
        //

        [TestMethod]
        public void MillionUpperLimit()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(999999999);
            Assert.IsTrue("Nine Hundred and Ninety-Nine Million and Nine Hundred and Ninety-Nine Thousand and Nine Hundred and Ninety-Nine Dollars".Equals(output));
        }

        [TestMethod]
        public void BillionLowerLimit() 
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(1000000000);
            Assert.IsTrue("One Billion Dollars".Equals(output));
        }

        [TestMethod]
        public void BillionLowerLimitPlusOne()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(1000000001);
            Assert.IsTrue("One Billion and One Dollars".Equals(output));
        }

        [TestMethod]
        public void ThousandsNumber()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(11234);
            Assert.IsTrue("Eleven Thousand and Two Hundred and Thirty-Four Dollars".Equals(output));
        }

        [TestMethod]
        public void DecimalNumber()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(242.45);
            Assert.IsTrue("Two Hundred and Forty-Two Dollars and Forty-Five cents".Equals(output));
        }


    }
}

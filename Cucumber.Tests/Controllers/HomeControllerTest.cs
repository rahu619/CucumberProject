using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cucumber;
using Cucumber.Controllers;
using Cucumber.BLL;

namespace Cucumber.Tests.Controllers
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TeenNumber()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(12);
            Assert.IsTrue("Twelve Dollars".Equals(output));
        }

        [TestMethod]
        public void TensNumber()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(42);
            Assert.IsTrue("Fourty-Two Dollars".Equals(output));
        }

        [TestMethod]
        public void HundredsNumber()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(-516.25);
            Assert.IsTrue("Two Hundred and Fourty-Two Dollars".Equals(output));
        }

        [TestMethod]
        public void ThousandsNumber()
        {
            var obj = new NumberToWord();
            var output = obj.GetWords(11234);
            Assert.IsTrue("One Thousand and Two Hundred and Forty-Two Dollars".Equals(output));
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

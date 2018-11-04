using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3_Triangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_Triangles.Tests
{
    [TestClass()]
    public class UITests
    {
        [TestMethod]
        public void IsExeption_CorrectValuesTest()
        {
            //arrange
            string value = "145,68";
            double expextedSide = 145.68;
            UI user = new UI();

            //act
            bool actual = user.IsException(ref expextedSide, value);

            //assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void IsExeption_IncorrectValuesTest()
        {
            //arrange
            string value = "145ftghjgk";
            double expextedSide = 145.68;
            UI user = new UI();

            //act
            bool actual = user.IsException(ref expextedSide, value);

            //assert
            Assert.AreEqual(false, actual);
        }
    }
}
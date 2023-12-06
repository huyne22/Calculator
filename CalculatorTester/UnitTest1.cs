using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Calculation c;
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void setup()
        {
            c = new Calculation(10, 5);
        }

        [TestMethod]
        public void TestAddOperation()
        {
            int expected, actual;
            expected = 15;
            actual = c.Exectute("+");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSubOperation()
        {
            int expected, actual;
            expected = 5;
            actual = c.Exectute("-");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMulOperation()
        {
            int expected, actual;
            expected = 50;
            actual = c.Exectute("*");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDivOperation()
        {
            int expected, actual;
            expected = 2;
            actual = c.Exectute("/");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivByZero()
        {
            c = new Calculation(10, 0);
            c.Exectute("/");
        }

        //Liên kết file csv đến project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSource()
        {
            int a, b, expected, actual;
            string operation;
            a = int.Parse(TestContext.DataRow[0].ToString());
            b = int.Parse(TestContext.DataRow[1].ToString());
            operation = TestContext.DataRow[2].ToString();
            operation = operation.Remove(0, 1);
            expected = int.Parse(TestContext.DataRow[3].ToString());
            Calculation c = new Calculation(a, b);
            actual = c.Exectute(operation);
            Assert.AreEqual(expected, actual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\TestDataPower.csv", "TestDataPower#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSourcePower()
        {
            int b;
            double a,actual, expected;
            a = double.Parse(TestContext.DataRow[0].ToString());
            b = int.Parse(TestContext.DataRow[1].ToString());
            expected = double.Parse(TestContext.DataRow[2].ToString());
            actual = Calculation.Power(a, b);
            Assert.AreEqual(expected, actual);
        }
    }
}

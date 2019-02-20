using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_4_and_5_results_9()
        {
            //Arrange
            var calc = new Calc();

            //Act   
            var result = calc.Sum(4, 5);

            //Assert                         
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act   
            var result = calc.Sum(0, 0);

            //Assert                         
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void Calc_Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }

        [TestMethod]
        [DataRow(2, 3, 5)]
        [DataRow(-2, 3, 1)]
        [DataRow(-2, -3, -5)]
        public void Calc_Sum(int a, int b, int soll)
        {
            //Arrange
            var calc = new Calc();

            //Act   
            var result = calc.Sum(a, b);

            //Assert                         
            Assert.AreEqual(soll, result);
        }

        [TestMethod]
        public void Calc_IsWeekend()
        {
            var calc = new Calc();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 2, 18);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 2, 19);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 2, 20);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 2, 21);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 2, 22);
                Assert.IsFalse(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 2, 23);
                Assert.IsTrue(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 2, 24);
                Assert.IsTrue(calc.IsWeekend());
            }
        }
    }
}

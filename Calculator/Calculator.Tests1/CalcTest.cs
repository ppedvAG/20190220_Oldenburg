// <copyright file="CalcTest.cs">Copyright ©  2019</copyright>
using System;
using Calculator;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    /// <summary>This class contains parameterized unit tests for Calc</summary>
    [PexClass(typeof(Calc))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CalcTest
    {
        /// <summary>Test stub for Sum(Int32, Int32)</summary>
        [PexMethod]
        public int SumTest(
            [PexAssumeUnderTest]Calc target,
            int a,
            int b
        )
        {
            int result = target.Sum(a, b);
            return result;
            // TODO: add assertions to method CalcTest.SumTest(Calc, Int32, Int32)
        }
    }
}

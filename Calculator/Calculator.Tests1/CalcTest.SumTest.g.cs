using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace Calculator.Tests
{
    public partial class CalcTest
    {

[TestMethod]
[PexGeneratedBy(typeof(CalcTest))]
public void SumTest608()
{
    int i;
    Calc s0 = new Calc();
    i = this.SumTest(s0, 0, 0);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)s0);
}

[TestMethod]
[PexGeneratedBy(typeof(CalcTest))]
[PexRaisedException(typeof(OverflowException))]
public void SumTestThrowsOverflowException250()
{
    int i;
    Calc s0 = new Calc();
    i = this.SumTest(s0, -100, int.MinValue);
}

[TestMethod]
[PexGeneratedBy(typeof(CalcTest))]
public void SumTest429()
{
    int i;
    Calc s0 = new Calc();
    i = this.SumTest(s0, int.MinValue, 0);
    Assert.AreEqual<int>(5, i);
    Assert.IsNotNull((object)s0);
}
    }
}

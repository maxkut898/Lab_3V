using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass()]
    public class RomanNumberTests
    {
        [TestMethod()]
        public void RomanNumberTest_ValidValue()
        {
            RomanNumber a = new RomanNumber(3594);
            int div=String.Compare(a.ToString(), "MMMDXCIV");
            Assert.AreEqual(0, div);
        }

        [TestMethod()]
        public void RomanNumberTest_NotValidValue()
        {
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumber(0));
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumber(4000));
        }

        [TestMethod()]
        public void RomanNumberTest_OperationAdd()
        {
            RomanNumber? a = new RomanNumber(2498);
            RomanNumber? b = new RomanNumber(1563);
            RomanNumber? c = null;
            Assert.AreEqual(0,(b+b).CompareTo(new RomanNumber(1563+1563)));
            Assert.ThrowsException<RomanNumberException>(() => a + c);
            Assert.ThrowsException<RomanNumberException>(() => c + b);
            Assert.ThrowsException<RomanNumberException>(() => a + b);
        }

        [TestMethod()]
        public void RomanNumberTest_OperationSub()
        {
            RomanNumber? a = new RomanNumber(2498);
            RomanNumber? b = new RomanNumber(1563);
            RomanNumber? c = null;
            Assert.AreEqual(0, (a - b).CompareTo(new RomanNumber(2498 - 1563)));
            Assert.ThrowsException<RomanNumberException>(() => a - c);
            Assert.ThrowsException<RomanNumberException>(() => c - b);
            Assert.ThrowsException<RomanNumberException>(() => b - a);
            Assert.ThrowsException<RomanNumberException>(() => b - b);
        }

        [TestMethod()]
        public void RomanNumberTest_OperationMul()
        {
            RomanNumber? a = new RomanNumber(73);
            RomanNumber? b = new RomanNumber(28);
            RomanNumber? c = null;
            Assert.AreEqual(0, (a * b).CompareTo(new RomanNumber(73 * 28)));
            Assert.ThrowsException<RomanNumberException>(() => a * c);
            Assert.ThrowsException<RomanNumberException>(() => c * b);
            Assert.ThrowsException<RomanNumberException>(() => a * a);
        }

        [TestMethod()]
        public void RomanNumberTest_OperationDiv()
        {
            ushort k = 3;
            RomanNumber? a = new RomanNumber(73);
            RomanNumber? b = new RomanNumber(28);
            RomanNumber? c = null;
            RomanNumber? d = new RomanNumber((ushort)(28*k));
            Assert.AreEqual(0, (d / b).CompareTo(new RomanNumber(k)));
            Assert.ThrowsException<RomanNumberException>(() => a / c);
            Assert.ThrowsException<RomanNumberException>(() => c / b);
            Assert.ThrowsException<RomanNumberException>(() => a / b);
            Assert.ThrowsException<RomanNumberException>(() => a / d);
        }

        [TestMethod()]
        public void CloneTest()
        {
            RomanNumber a = new RomanNumber(12);
            RomanNumber b = (RomanNumber)a.Clone();
            Assert.AreNotEqual(a, b);
            Assert.AreEqual(0,a.CompareTo(b));
        }

        [TestMethod()]
        public void CompareToTest_ValidValue()
        {
            RomanNumber a = new RomanNumber(12);
            RomanNumber b = new RomanNumber(15);
            Assert.IsTrue(a.CompareTo(b) < 0);
            b = new RomanNumber(10);
            Assert.IsTrue(a.CompareTo(b) > 0);
            b = a;
            Assert.IsTrue(a.CompareTo(b) == 0);
        }

        public void CompareToTest_NotValidValue()
        {
            RomanNumber a = new RomanNumber(42);
            Assert.ThrowsException<ArgumentException>(() => a.CompareTo(100));
        }
    }
}
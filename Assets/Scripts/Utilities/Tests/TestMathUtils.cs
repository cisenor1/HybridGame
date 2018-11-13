using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
namespace HybridGame
{
    public class TestMathUtils
    {
        [Test]
        public void TestPositiveZeroish(){
            float value = 0.000000003f;
            Assert.IsTrue(MathUtils.isZeroish(value));
        }

        [Test]
        public void TestNegativeZeroish()
        {
            float value = -0.000000003f;
            Assert.IsTrue(MathUtils.isZeroish(value));
        }

        [Test]
        public void TestLargePositive()
        {
            float value = 10f;
            Assert.IsFalse(MathUtils.isZeroish(value));
        }

        [Test]
        public void TestLargeNegative()
        {
            float value = -10f;
            Assert.IsFalse(MathUtils.isZeroish(value));
        }
    }
}

using Strides;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace StridesTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCaseSource("StridesComputationTestSet")]
        public int TestAlgorithmWithStrides(int[] stairs, int pace)
        {
            var result = AlgorithmHolder.ComputeNumberOfStrides(stairs, pace);

            return result;
        }

        public static IEnumerable StridesComputationTestSet
        {
            get
            {
                yield return new TestCaseData(new int[] { 15 }, 2).Returns(8);
                yield return new TestCaseData(new int[] { 15, 15 }, 2).Returns(18);
                yield return new TestCaseData(new int[] { 5, 11, 9, 13, 8, 30, 14 }, 3).Returns(44);
            }
        }

        [Test]
        [TestCaseSource("Add_Source")]
        public AddResult TestAlgorithWithRecursiveAddition(byte[] f, byte[] s)
        {
            var result = AlgorithmHolder.AddRecursive(f, s);

            return new AddResult(f, s, result);
        }

        public static IEnumerable Add_Source
        {
            get
            {
                yield return new TestCaseData(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 }).Returns(new AddResult(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 }, new byte[] { 2, 2, 2 }));
                yield return new TestCaseData(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 }).Returns(new AddResult(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 }, new byte[] { 1, 2, 0 }));
            }
        }

        [Test]
        [TestCaseSource("BombsComputationSource")]
        public int TestAlgorithmWithBombs(int numberOfBombs, int[][] bombsLocations)
        {
            var result = AlgorithmHolder.ComputeSafestPlaceDistance(numberOfBombs, bombsLocations);

            return result;
        }

        public static IEnumerable BombsComputationSource
        {
            get
            {
                yield return new TestCaseData(1, new int[][] { new int[] { 0, 0, 0 } }).Returns(1000000000);
            }
        }
    }
}

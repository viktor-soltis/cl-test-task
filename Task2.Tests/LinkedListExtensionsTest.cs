using System.Collections.Generic;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture, Description("Should test LinkedListExtension methods for a propper work condition")]
    public class LinkedListExtensionsTest
    {
        private LinkedList<int> _linkedListInt;
        private LinkedList<string> _linkedListString;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            _linkedListInt = new LinkedList<int>();
            _linkedListString = new LinkedList<string>();
        }

        [Test, Description("Should check if linked list size is lower then seeking position handeled correctly")]
        public void IsIncorrectLinkedListSizeHandeled()
        {
            const int incorrectListSize = 4;
            const int listPositionToGet = 5;

            for (int i = 0; i < incorrectListSize; i++)
            {
                _linkedListInt.AddLast(i);
                _linkedListString.AddLast(string.Format("Current value is: {0}", i));
            }

            var actualIntListResult = _linkedListInt.NthToLast(listPositionToGet);
            var actualStringListResult = _linkedListString.NthToLast(listPositionToGet);

            Assert.IsNull(actualIntListResult);
            Assert.IsNull(actualStringListResult);
        }

        [Test, Description("Should check if linked list NthToLast method returns expected result")]
        public void IsCorrectLinkedListSizeHandeled()
        {
            const int correctListSize = 10;
            const int listPositionToGet = 5;
            LinkedListNode<int> expectedIntListNode = new LinkedListNode<int>(5);
            LinkedListNode<string> expectedStringListNode = new LinkedListNode<string>("Current value is: 5");

            for (int i = 0; i < correctListSize; i++)
            {
                _linkedListInt.AddLast(i);
                _linkedListString.AddLast(string.Format("Current value is: {0}", i));
            }

            var actualIntListResult = _linkedListInt.NthToLast(listPositionToGet);
            var actualStringListResult = _linkedListString.NthToLast(listPositionToGet);

            Assert.AreEqual(expectedIntListNode.Value, actualIntListResult.Value);
            Assert.AreEqual(expectedStringListNode.Value, actualStringListResult.Value);
        }

        [Test, Description("Should check if empty linked list is handeled correctly")]
        public void IsCorrectEmptyLinkedListSizeHandeled()
        {
            const int listPositionToGet = 5;

            var actualIntListResult = _linkedListInt.NthToLast(listPositionToGet);
            var actualStringListResult = _linkedListString.NthToLast(listPositionToGet);

            Assert.IsNull(actualIntListResult);
            Assert.IsNull(actualStringListResult);
        }

        [Test, Description("Should check if null linked list is handeled")]
        public void IsNullLinkedListHandeled()
        {
            const int listPositionToGet = 5;

            _linkedListInt = null;
            _linkedListString = null;

            var actualIntListResult = _linkedListInt.NthToLast(listPositionToGet);
            var actualStringListResult = _linkedListString.NthToLast(listPositionToGet);

            Assert.IsNull(actualIntListResult);
            Assert.IsNull(actualStringListResult);
        }

        [Test, Description("Should check if seek number < 1 is handeled")]
        public void IsIncorrectSeekNumberHandeled()
        {
            const int correctListSize = 10;
            const int zeroListPositionToGet = 0;
            const int negativeListPositionToGet = -10;

            for (int i = 0; i < correctListSize; i++)
            {
                _linkedListInt.AddLast(i);
                _linkedListString.AddLast(string.Format("Current value is: {0}", i));
            }

            var actualIntListResultWithZero = _linkedListInt.NthToLast(zeroListPositionToGet);
            var actualStringListResultWithZero = _linkedListString.NthToLast(zeroListPositionToGet);

            var actualIntListResultWithNegative = _linkedListInt.NthToLast(negativeListPositionToGet);
            var actualStringListResultWithNegative = _linkedListString.NthToLast(negativeListPositionToGet);

            Assert.IsNull(actualIntListResultWithZero);
            Assert.IsNull(actualStringListResultWithZero);

            Assert.IsNull(actualIntListResultWithNegative);
            Assert.IsNull(actualStringListResultWithNegative);
        }

        [TearDown]
        public void TestTearDown()
        {
            _linkedListInt = null;
            _linkedListString = null;
        }
    }
}

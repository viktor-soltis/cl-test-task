using NUnit.Framework;
using Task1.Enum;

namespace Task1.Tests
{
    [TestFixture, Description("Should test TriangleTyper methods for a propper work condition")]
    public class TriangleTyperTest
    {
        private TriangleTyper _triangleTyper;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            _triangleTyper = new TriangleTyper(0, 0, 0);
        }

        [Test, Description("Should check if figure sides are valid")]
        public void IsFigureSidesAreValid()
        {
            _triangleTyper.SideA = 12;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 12;

            bool actualResult = _triangleTyper.AreSidesValid();

            Assert.IsTrue(actualResult);
        }

        [Test, Description("Should check if figure sides are not valid")]
        public void IsFigureSidesAreNotValid()
        {
            _triangleTyper.SideA = 0;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 12;

            bool actualResult = _triangleTyper.AreSidesValid();

            Assert.IsFalse(actualResult);
        }

        [Test, Description("Should check if figure is a triangle")]
        public void IsFigureIsTriangle()
        {
            _triangleTyper.SideA = 12;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 12;

            bool actualSidesResult = _triangleTyper.AreSidesValid();
            bool actualTriangleResult = _triangleTyper.IsTriangle();

            Assert.IsTrue(actualSidesResult);
            Assert.IsTrue(actualTriangleResult);
        }

        [Test, Description("Should check if figure is not a triangle")]
        public void IsFigureIsNotTriangle()
        {
            _triangleTyper.SideA = 0;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 12;

            bool actualSidesResult = _triangleTyper.AreSidesValid();
            bool actualTriangleResult = _triangleTyper.IsTriangle();

            Assert.IsFalse(actualSidesResult);
            Assert.IsFalse(actualTriangleResult);
        }

        [Test, Description("Should check if presented figure is a Scalene triangle")]
        public void IsTriangleScalene()
        {
            _triangleTyper.SideA = 12;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 12;

            bool isScalene = _triangleTyper.IsScalene();

            Assert.IsFalse(isScalene);
        }

        [Test, Description("Should check if presented figure is not a Scalene triangle")]
        public void IsTriangleNotScalene()
        {
            _triangleTyper.SideA = 17;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 12;

            bool isScalene = _triangleTyper.IsScalene();

            Assert.IsFalse(isScalene);
        }

        [Test, Description("Should check if presented figure is a Isosceles triangle")]
        public void IsTriangleIsosceles()
        {
            _triangleTyper.SideA = 17;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 12;

            bool isIsosceles = _triangleTyper.IsIsosceles();

            Assert.IsTrue(isIsosceles);
        }

        [Test, Description("Should check if presented figure is not a Isosceles triangle")]
        public void IsTriangleNotIsosceles()
        {
            _triangleTyper.SideA = 17;
            _triangleTyper.SideB = 15;
            _triangleTyper.SideC = 12;

            bool isIsosceles = _triangleTyper.IsIsosceles();

            Assert.IsFalse(isIsosceles);
        }

        [Test, Description("Should check if presented figure is a Equilateral triangle")]
        public void IsTriangleEquilateral()
        {
            _triangleTyper.SideA = 12;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 12;

            bool isEquilateral = _triangleTyper.IsEquilateral();

            Assert.IsTrue(isEquilateral);
        }

        [Test, Description("Should check if presented figure is not a Equilateral triangle")]
        public void IsTriangleNotEquilateral()
        {
            _triangleTyper.SideA = 17;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 12;

            bool isEquilateral = _triangleTyper.IsEquilateral();

            Assert.IsFalse(isEquilateral);
        }

        [Test, Description("Should check if presented figure is a Equilateral triangle")]
        public void IsTriangleTypeIsEquilateral()
        {
            _triangleTyper.SideA = 12;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 12;

            TriangleTypeEnum triangleType = _triangleTyper.GetTriangleType();

            Assert.AreNotEqual(triangleType, TriangleTypeEnum.Isosceles);
            Assert.AreNotEqual(triangleType, TriangleTypeEnum.Scalene);
            Assert.AreEqual(triangleType, TriangleTypeEnum.Equilateral);
        }

        [Test, Description("Should check if presented figure is a Scalene triangle")]
        public void IsTriangleTypeIsScalene()
        {
            _triangleTyper.SideA = 10;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 17;

            TriangleTypeEnum triangleType = _triangleTyper.GetTriangleType();

            Assert.AreNotEqual(triangleType, TriangleTypeEnum.Isosceles);
            Assert.AreEqual(triangleType, TriangleTypeEnum.Scalene);
            Assert.AreNotEqual(triangleType, TriangleTypeEnum.Equilateral);
        }

        [Test, Description("Should check if presented figure is a Isosceles triangle")]
        public void IsTriangleTypeIsIsosceles()
        {
            _triangleTyper.SideA = 12;
            _triangleTyper.SideB = 12;
            _triangleTyper.SideC = 17;

            TriangleTypeEnum triangleType = _triangleTyper.GetTriangleType();

            Assert.AreEqual(triangleType, TriangleTypeEnum.Isosceles);
            Assert.AreNotEqual(triangleType, TriangleTypeEnum.Scalene);
            Assert.AreNotEqual(triangleType, TriangleTypeEnum.Equilateral);
        }

        [Test, Description("Should check if presented figure is not any of TriangleTypeEnum (Isosceles, Scalene, Equilateral)")]
        public void IsTriangleTypeIsNotOfCheckedType()
        {
            _triangleTyper.SideA = 0;
            _triangleTyper.SideB = 4;
            _triangleTyper.SideC = 3;

            TriangleTypeEnum triangleType = _triangleTyper.GetTriangleType();

            Assert.AreNotEqual(triangleType, TriangleTypeEnum.Isosceles);
            Assert.AreNotEqual(triangleType, TriangleTypeEnum.Scalene);
            Assert.AreNotEqual(triangleType, TriangleTypeEnum.Equilateral);
        }


        [TearDown]
        public void TestTearDown()
        {
            _triangleTyper = null;
        }
    }
}

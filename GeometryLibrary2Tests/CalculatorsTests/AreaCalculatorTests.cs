using GeometryLibrary2.Calculators;
using GeometryLibrary2.DefaultFigures;
using GeometryLibrary2Tests.CustomFiguresForTests;

namespace GeometryLibrary2Tests.CalculatorsTests
{
    /// <summary>
    /// Tests for the ShapeAreaCalculator class.
    /// </summary>
    public class AreaCalculatorTests
    {
        /// <summary>
        /// Tests that the ShapeAreaCalculator can correctly calculate the area of a Circle.
        /// </summary>
        [Fact]
        public void ShapeAreaCalculator_CalculateArea_CalculatesCircleArea()
        {
            var circle = new Circle(5);
            var expectedArea = Math.PI * 5 * 5;
            var area = AreaCalculator.CalculateArea(circle);

            Assert.Equal(expectedArea, area, 5);
        }

        /// <summary>
        /// Tests that the ShapeAreaCalculator can correctly calculate the area of a Triangle.
        /// </summary>
        [Fact]
        public void ShapeAreaCalculator_CalculateArea_CalculatesTriangleArea()
        {
            var triangle = new Triangle(3, 4, 5);
            var expectedArea = 6.0;
            var area = AreaCalculator.CalculateArea(triangle);

            Assert.Equal(expectedArea, area);
        }

        /// <summary>
        /// Tests that the ShapeAreaCalculator can register and calculate the area of a custom shape.
        /// </summary>
        [Fact]
        public void ShapeAreaCalculator_RegisterCustomHandler_CalculatesCustomShapeArea()
        {
            var customShape = new CustomAreaCalculatable(10, 20);
            AreaCalculator.RegisterHandler<CustomAreaCalculatable>(shape => shape.Width * shape.Height);
            var expectedArea = 200.0; 
            var area = AreaCalculator.CalculateArea(customShape);

            Assert.Equal(expectedArea, area);
        }

        /// <summary>
        /// Tests that the ShapeAreaCalculator throws NotSupportedException when calculating the area of an unsupported shape.
        /// </summary>
        [Fact]
        public void ShapeAreaCalculator_UnsupportedShape_ThrowsNotSupportedException()
        {
            var unsupportedShape = new UnsupportedAreaCalculatable();

            Assert.Throws<NotSupportedException>(() => AreaCalculator.CalculateArea(unsupportedShape));
        }
    }
}
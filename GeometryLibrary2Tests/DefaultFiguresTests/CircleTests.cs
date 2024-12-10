using GeometryLibrary2.DefaultFigures;

namespace GeometryLibrary2Tests.DefaultFiguresTests
{
    /// <summary>
    /// Tests for the Circle class.
    /// </summary>
    public class CircleTests
    {
        /// <summary>
        /// Tests that a Circle object can be created with a valid radius.
        /// </summary>
        [Fact]
        public void Circle_ValidRadius_CreatesCircle()
        {
            var radius = 5.0;
            var circle = new Circle(radius);

            Assert.Equal(radius, circle.Radius);
        }

        /// <summary>
        /// Tests that an ArgumentException is thrown when creating a Circle with a negative radius.
        /// </summary>
        [Fact]
        public void Circle_NegativeRadius_ThrowsArgumentException()
        {
            var negativeRadius = -5.0;

            Assert.Throws<ArgumentException>(() => new Circle(negativeRadius));
        }
    }
}

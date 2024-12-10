using GeometryLibrary2.Interfaces;

namespace GeometryLibrary2.DefaultFigures
{
    /// <summary>
    /// Represents a triangle with three sides and provides functionality to check if the triangle is a right triangle.
    /// </summary>
    public class Triangle : IAreaCalculatable
    {
        /// <summary>
        /// The length of the first side of the triangle.
        /// </summary>
        public double SideA { get; }

        /// <summary>
        /// The length of the second side of the triangle.
        /// </summary>
        public double SideB { get; }

        /// <summary>
        /// The length of the third side of the triangle.
        /// </summary>
        public double SideC { get; }

        /// <summary>
        /// Indicates whether the triangle is a right triangle.
        /// </summary>
        public bool IsRightTriangle { get; private set; }

        /// <summary>
        /// Measurement error threshold for checking if the triangle is right-angled.
        /// This precision is chosen to accommodate floating-point arithmetic limitations.
        /// </summary>
        private const double MeasurementError = 1e-10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class with the given side lengths.
        /// </summary>
        /// <param name="sideA">The length of the first side.</param>
        /// <param name="sideB">The length of the second side.</param>
        /// <param name="sideC">The length of the third side.</param>
        /// <exception cref="ArgumentException">Thrown when any side length is less than or equal to zero, or when the sides do not form a valid triangle.</exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("Sides must be greater than zero.");
            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
                throw new ArgumentException("The sum of any two sides must be greater than the third side.");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            
            IsTriangleRight();
        }

        /// <summary>
        /// Determines whether the triangle is a right triangle by checking if the Pythagorean theorem holds for the sides.
        /// </summary>
        private void IsTriangleRight()
        {
            double[] sides = [SideA, SideB, SideC];
            Array.Sort(sides);

            IsRightTriangle = Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < MeasurementError;
        }
    }
}

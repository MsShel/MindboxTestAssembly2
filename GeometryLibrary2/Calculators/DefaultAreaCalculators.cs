using GeometryLibrary2.DefaultFigures;

namespace GeometryLibrary2.Calculators
{
    public static class DefaultAreaCalculators
    {
        /// <summary>
        /// Default area calculation for a Circle.
        /// </summary>
        /// <param name="circle">The Circle object.</param>
        /// <returns>The area of the circle.</returns>
        public static double CalculateCircleArea(Circle circle)
        {
            return Math.PI * circle.Radius * circle.Radius;
        }

        /// <summary>
        /// Default area calculation for a Triangle. Uses different formulas based on whether the triangle is a right triangle or not.
        /// </summary>
        /// <param name="triangle">The Triangle object.</param>
        /// <returns>The area of the triangle.</returns>
        public static double CalculateTriangleArea(Triangle triangle)
        {
            return triangle.IsRightTriangle ? CalculateRightTriangleArea(triangle) : CalculateNotRightTriangleArea(triangle);
        }

        /// <summary>
        /// Calculates the area of a right triangle using the formula: (base * height) / 2.
        /// </summary>
        /// <param name="triangle">The right Triangle object.</param>
        /// <returns>The area of the right triangle.</returns>
        private static double CalculateRightTriangleArea(Triangle triangle)
        {
            return triangle.SideA * triangle.SideB / 2;
        }

        /// <summary>
        /// Calculates the area of a non-right triangle using Heron's formula.
        /// </summary>
        /// <param name="triangle">The non-right Triangle object.</param>
        /// <returns>The area of the non-right triangle.</returns>
        private static double CalculateNotRightTriangleArea(Triangle triangle)
        {
            var semiPerimeter = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - triangle.SideA) * (semiPerimeter - triangle.SideB) *
                             (semiPerimeter - triangle.SideC));
        }
    }
}
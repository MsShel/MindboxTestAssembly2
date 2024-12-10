using GeometryLibrary2.Interfaces;

namespace GeometryLibrary2.DefaultFigures
{
    /// <summary>
    /// Represents a circle and provides properties related to its geometry.
    /// </summary>
    public class Circle : IAreaCalculatable
    {
        /// <summary>
        /// The radius of the circle.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class with the specified radius.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <exception cref="ArgumentException">Thrown when the radius is negative.</exception>
        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Radius must not be negative.");

            Radius = radius;
        }
    }
}
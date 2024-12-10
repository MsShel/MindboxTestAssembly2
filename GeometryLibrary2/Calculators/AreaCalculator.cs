using GeometryLibrary2.DefaultFigures;
using GeometryLibrary2.Interfaces;

namespace GeometryLibrary2.Calculators
{
    /// <summary>
    /// A utility class for calculating the area of shapes by dynamically registering area calculation handlers.
    /// The class supports default area calculators for Triangle and Circle, and allows the registration of custom handlers for other shape types.
    /// </summary>
    public static class AreaCalculator
    {
        /// <summary>
        /// A dictionary holding the registered area calculation handlers, where the key is the shape type,
        /// and the value is a function that calculates the area for that shape type.
        /// </summary>
        private static readonly Dictionary<Type, Func<IAreaCalculatable, double>> _handlers = new();

        /// <summary>
        /// Static constructor to register default area calculation handlers for supported shapes (Circle and Triangle).
        /// </summary>
        static AreaCalculator()
        {
            RegisterHandler<Triangle>(DefaultAreaCalculators.CalculateTriangleArea);
            RegisterHandler<Circle>(DefaultAreaCalculators.CalculateCircleArea);
        }

        /// <summary>
        /// Registers a custom area calculation handler for a specific shape type.
        /// </summary>
        /// <typeparam name="T">The shape type (must implement IShape).</typeparam>
        /// <param name="areaCalculator">A function that calculates the area of the shape.</param>
        public static void RegisterHandler<T>(Func<T, double> areaCalculator) where T : IAreaCalculatable
        {
            _handlers[typeof(T)] = shape => areaCalculator((T) shape);
        }

        /// <summary>
        /// Calculates the area of a given shape by using the appropriate registered handler.
        /// </summary>
        /// <param name="areaCalculatable">An instance of a shape implementing IShape.</param>
        /// <returns>The area of the shape.</returns>
        /// <exception cref="NotSupportedException">Thrown if no area handler is registered for the shape type.</exception>
        public static double CalculateArea(IAreaCalculatable areaCalculatable)
        {
            var shapeType = areaCalculatable.GetType();

            if (_handlers.TryGetValue(shapeType, out var handler))
            {
                return handler(areaCalculatable);
            }

            throw new NotSupportedException($"No area handler registered for shape type {shapeType.Name}");
        }
    }
}

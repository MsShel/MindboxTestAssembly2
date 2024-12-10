using GeometryLibrary2.Interfaces;

namespace GeometryLibrary2Tests.CustomFiguresForTests
{
    /// <summary>
    /// A custom shape used for testing ShapeAreaCalculator with custom handlers.
    /// </summary>
    public class CustomAreaCalculatable : IAreaCalculatable
    {
        public double Width { get; }
        public double Height { get; }

        public CustomAreaCalculatable(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}
using GeometryLibrary2.DefaultFigures;

namespace GeometryLibrary2Tests.DefaultFiguresTests;

/// <summary>
/// Tests for the Triangle class.
/// </summary>
public class TriangleTests
{
    /// <summary>
    /// Tests that a Triangle object can be created with valid side lengths.
    /// </summary>
    [Fact]
    public void Triangle_ValidSides_CreatesTriangle()
    {
        double sideA = 3.0, sideB = 4.0, sideC = 5.0;
        var triangle = new Triangle(sideA, sideB, sideC);

        Assert.Equal(sideA, triangle.SideA);
        Assert.Equal(sideB, triangle.SideB);
        Assert.Equal(sideC, triangle.SideC);
    }

    /// <summary>
    /// Tests that a Triangle object calculates IsRightTriangle property correctly.
    /// </summary>
    [Fact]
    public void Triangle_ValidSides_CreatesRightTriangle()
    {
        double sideA = 3.0, sideB = 4.0, sideC = 5.0;
        var triangle = new Triangle(sideA, sideB, sideC);

        Assert.True(triangle.IsRightTriangle);
    }

    /// <summary>
    /// Tests that an ArgumentException is thrown when the sides do not form a valid triangle.
    /// </summary>
    [Theory]
    [InlineData(1, 1, 10)]
    [InlineData(0, 4, 5)]
    [InlineData(2, 3, -4)]
    public void Triangle_InvalidSides_ThrowsArgumentException(double sideA, double sideB, double sideC)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }
}
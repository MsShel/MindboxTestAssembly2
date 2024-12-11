Пример использования
```c#
static void Main(string[] args)
{
    // Пример добавления пользовательской фигуры
    var customShape = new CustomShape(6, 8);
    AreaCalculator.RegisterHandler<CustomShape>(s => s.Width * s.Height);
    Console.WriteLine($"Area of CustomShape: {AreaCalculator.CalculateArea(customShape)}");
}

// Пользовательская фигура
public class CustomShape(double width, double height) : IAreaCalculatable
{
    public double Width { get; set; } = width;
    public double Height { get; set; } = height;
}
```


# GeometryLibrary2

## Assembly
- **Name**: GeometryLibrary2

## Classes

### `GeometryLibrary2.Calculators.AreaCalculator`
A utility class for calculating the area of shapes by dynamically registering area calculation handlers. The class supports default area calculators for `Triangle` and `Circle`, and allows the registration of custom handlers for other shape types.

#### Fields
- **_handlers**  
  A dictionary holding the registered area calculation handlers, where the key is the shape type, and the value is a function that calculates the area for that shape type.

#### Methods
- **`#cctor`**  
  Static constructor to register default area calculation handlers for supported shapes (Circle and Triangle).

- **`RegisterHandler<T>(System.Func<T, System.Double>)`**  
  Registers a custom area calculation handler for a specific shape type.  
  - **T**: The shape type (must implement `IShape`).  
  - **areaCalculator**: A function that calculates the area of the shape.

- **`CalculateArea(GeometryLibrary2.Interfaces.IAreaCalculatable)`**  
  Calculates the area of a given shape by using the appropriate registered handler.  
  - **areaCalculatable**: An instance of a shape implementing `IShape`.  
  - **Returns**: The area of the shape.  
  - **Throws**: `System.NotSupportedException` if no area handler is registered for the shape type.

### `GeometryLibrary2.Calculators.DefaultAreaCalculators`
Contains default area calculation methods for various shapes.

#### Methods
- **`CalculateCircleArea(GeometryLibrary2.DefaultFigures.Circle)`**  
  Default area calculation for a `Circle`.  
  - **circle**: The Circle object.  
  - **Returns**: The area of the circle.

- **`CalculateTriangleArea(GeometryLibrary2.DefaultFigures.Triangle)`**  
  Default area calculation for a `Triangle`. Uses different formulas based on whether the triangle is a right triangle or not.  
  - **triangle**: The Triangle object.  
  - **Returns**: The area of the triangle.

- **`CalculateRightTriangleArea(GeometryLibrary2.DefaultFigures.Triangle)`**  
  Calculates the area of a right triangle using the formula: `(base * height) / 2`.  
  - **triangle**: The right Triangle object.  
  - **Returns**: The area of the right triangle.

- **`CalculateNotRightTriangleArea(GeometryLibrary2.DefaultFigures.Triangle)`**  
  Calculates the area of a non-right triangle using Heron's formula.  
  - **triangle**: The non-right Triangle object.  
  - **Returns**: The area of the non-right triangle.

### `GeometryLibrary2.DefaultFigures.Circle`
Represents a circle and provides properties related to its geometry.

#### Properties
- **Radius**  
  The radius of the circle.

#### Methods
- **`#ctor(System.Double)`**  
  Initializes a new instance of the `Circle` class with the specified radius.  
  - **radius**: The radius of the circle.  
  - **Throws**: `System.ArgumentException` if the radius is negative.

### `GeometryLibrary2.DefaultFigures.Triangle`
Represents a triangle with three sides and provides functionality to check if the triangle is a right triangle.

#### Properties
- **SideA**  
  The length of the first side of the triangle.

- **SideB**  
  The length of the second side of the triangle.

- **SideC**  
  The length of the third side of the triangle.

- **IsRightTriangle**  
  Indicates whether the triangle is a right triangle.

- **MeasurementError**  
  Measurement error threshold for checking if the triangle is right-angled. This precision is chosen to accommodate floating-point arithmetic limitations.

#### Methods
- **`#ctor(System.Double, System.Double, System.Double)`**  
  Initializes a new instance of the `Triangle` class with the given side lengths.  
  - **sideA**: The length of the first side.  
  - **sideB**: The length of the second side.  
  - **sideC**: The length of the third side.  
  - **Throws**: `System.ArgumentException` if any side length is less than or equal to zero, or if the sides do not form a valid triangle.

- **`IsTriangleRight()`**  
  Determines whether the triangle is a right triangle by checking if the Pythagorean theorem holds for the sides.

### `GeometryLibrary2.Interfaces.IAreaCalculatable`
The base interface for all geometric shapes. Any shape class should implement this interface to ensure they can be handled generically by the area calculator.

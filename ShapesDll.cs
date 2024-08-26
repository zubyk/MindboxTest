namespace ShapesDll
{
    /// <summary>
    /// просто абстрактный класс для группировки фигур
    /// </summary>
    public abstract class Shape
    {
    }

    /// <summary>
    /// Интерфейсы лучше чем объявлять метод в абстрактном <see cref="Shape"/>. Не у всех фигур есть площадь.
    /// </summary>
    public interface IShapeSquare
    {
        public double Square();
    }

    /// <summary>
    /// Проверку на то, является ли треугольник прямоугольным
    /// </summary>
    public interface IRectangular
    {
        public bool IsRectangular();
    }

    public class CircleShape : Shape, IShapeSquare
    {
        private readonly double _radius;

        public CircleShape(double radius)
        {
            if (radius <= 0) throw new ArgumentException($"{nameof(radius)} must be greater than 0", nameof(radius));
            _radius = radius;
        }
        
        public double Square()
        {
            return Math.PI * _radius * _radius;
        }
    }

    public class TriangleShape : Shape, IShapeSquare, IRectangular
    {
        private readonly double _side1, _side2, _side3;

        public TriangleShape(double side1, double side2, double side3)
        {
            if (side1 <= 0) throw new ArgumentException($"{nameof(side1)} must be greater than 0", nameof(side1));
            if (side2 <= 0) throw new ArgumentException($"{nameof(side2)} must be greater than 0", nameof(side2));
            if (side3 <= 0) throw new ArgumentException($"{nameof(side3)} must be greater than 0", nameof(side3));

            // надо добавить остальные правила проверки на корректность сторон, но суть задания не в этом

            _side1 = side1;
            _side2 = side2;
            _side3 = side3;
        }

        public bool IsRectangular()
        {
            // лучше считать через углы, но суть задания не в этом
            var squareSide1 = _side1 * _side1;
            var squareSide2 = _side2 * _side2;
            var squareSide3 = _side3 * _side3;

            return (squareSide1 + squareSide2 == squareSide3)
                || (squareSide3 + squareSide1 == squareSide2)
                || (squareSide2 + squareSide3 == squareSide1);
        }

        public double Square()
        {
            var p = (_side1 + _side2 + _side3) / 2;
            return Math.Sqrt(p * (p - _side1) * (p - _side2) * (p - _side3));
        }
    }
}

















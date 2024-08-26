using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapesDll;

namespace ShapesDll.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Create_Circle()
        {
            double radius = 10.5;
            double square = Math.PI * radius * radius;
            
            var circle = new CircleShape(radius);

            Assert.AreEqual(circle.Square(), square, 0, $"Invalid {nameof(CircleShape.Square)} result");
        }

        [TestMethod]
        public void Create_Circle_ZeroRadius()
        {
            double radius = 0;

            try
            {
                var circle = new CircleShape(radius);
            }
            catch (ArgumentException e)
            {
                return;
            }

            Assert.Fail($"{nameof(ArgumentException)} must be thrown");
        }

        [TestMethod]
        public void Create_Circle_NegativeRadius()
        {
            double radius = -10;

            try
            {
                var circle = new CircleShape(radius);
            }
            catch (ArgumentException e)
            {
                return;
            }

            Assert.Fail($"{nameof(ArgumentException)} must be thrown");
        }

        /// <summary>
        /// Вычисление площади фигуры без знания типа фигуры в compile-time
        /// </summary>
        [TestMethod]
        public void MultiShape_Square()
        {
            var shapes = new Shape[]
            {
                new CircleShape(10),
                new TriangleShape(10, 10, 10),
            };

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                // проверить что компилятор не удалит вызов при оптимизации
                _ = shapes.OfType<IShapeSquare>().Select(shape => shape.Square());
            });
        }

    }
}

using System;
using System.Numerics;

namespace RobotChallenge
{
    public struct IntVector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Applies a matrix transformation to the vector
        /// </summary>
        /// <param name="vect">Vector being transformed</param>
        /// <param name="matrix">Transformation matrix</param>
        /// <returns>Transformed Vector</returns>
        public static IntVector2 Transform(IntVector2 vect, Matrix3x2 matrix)
        {
            return new IntVector2(
                (int)Math.Round(vect.X * matrix.M11 + vect.Y * matrix.M21 + matrix.M31),
                (int)Math.Round(vect.X * matrix.M12 + vect.Y * matrix.M22 + matrix.M32));
        }

        /// <summary>
        /// Logic to add two vectors.
        /// </summary>
        /// <param name="vect1">First Vector</param>
        /// <param name="vect2">Second Vector</param>
        /// <returns>Addition of first and second vector</returns>
        public static IntVector2 operator +(IntVector2 vect1, IntVector2 vect2) => new IntVector2(vect1.X + vect2.X, vect1.Y + vect2.Y);

    }
}
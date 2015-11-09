using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(int order)
        {
            if (order < 0)
                throw new ArgumentException("Order is less than zero");

            _matrix = new T[order, order];
        } 

        public SquareMatrix(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new SquareMatrixException("Input matrix is not square");

            СonversionMatrix(matrix);
            Order = matrix.GetLength(0);
        }

        protected override void SetValue(T value, int i, int j)
        {
            _matrix[i, j] = value;
        }

        private void СonversionMatrix(T[,] sourceMatrix)
        {
            int newSize = sourceMatrix.GetLength(0);
            _matrix = new T[newSize, newSize];
            for (int i = 0; i < newSize; i++)
                for (int j = 0; j < newSize; j++)
                    _matrix[i, j] = sourceMatrix[i, j];
        }
    }
}

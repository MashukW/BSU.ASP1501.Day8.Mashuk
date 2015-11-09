using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public sealed class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int order) : base(order)
        {
        }

        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            СonversionMatrix(matrix);
        }

        protected override void SetValue(T value, int i, int j)
        {
            if (i == j)
                base.SetValue(value, i, j);
        }

        private void СonversionMatrix(T[,] sourceMatrix)
        {
            int size = sourceMatrix.GetLength(0);
            _matrix = new T[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i == j)
                        _matrix[i, j] = sourceMatrix[i, j];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public sealed class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(int order) : base(order)
        {
        }

        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            TransposeMatrix(matrix);
        }

        private void TransposeMatrix(T[,] sourceMatrix)
        {
            int size = sourceMatrix.GetLength(0);
            _matrix = new T[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    _matrix[i, j] = sourceMatrix[j, i];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace Matrix
{
    public static class ExtensionsMethodMatrix
    {
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> matrix, SquareMatrix<T> addMatrix)
        {
            if (addMatrix == null)
                throw new AddMatrixException("Add Matrix is invalid");

            if (matrix.Order != addMatrix.Order)
                throw new AddMatrixException("The matrices are of different order");

            SquareMatrix<T> resultMatrix = new SquareMatrix<T>(matrix.Order);
            for (int i = 0; i < resultMatrix.Order; i++)
            {
                for (int j = 0; j < resultMatrix.Order; j++)
                {
                    try
                    {
                        resultMatrix[i, j] = (dynamic)matrix[i, j] + (dynamic)addMatrix[i, j];
                    }
                    catch (RuntimeBinderException e)
                    {
                        throw new AddMatrixException("It is impossible to perform addition of two matrices of type");
                    }
                }
            }

            return resultMatrix;
        }
    }
}

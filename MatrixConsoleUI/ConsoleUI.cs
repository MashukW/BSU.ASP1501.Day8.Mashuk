using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;

namespace MatrixConsoleUI
{
    class ConsoleUI
    {
        static void Main(string[] args)
        {
            int[,] arrayMatrix =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
            };

            SubscriberMatrix subscriber = new SubscriberMatrix();

            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(arrayMatrix);
            SquareMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(arrayMatrix);
            SquareMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(arrayMatrix);
            
            subscriber.SubscribeToMatrixEvents(squareMatrix);
            subscriber.SubscribeToMatrixEvents(symmetricMatrix);
            subscriber.SubscribeToMatrixEvents(diagonalMatrix);

            squareMatrix[0, 0] = 8;
            symmetricMatrix[0, 2] = 15;
            diagonalMatrix[1, 0] = 9;

            subscriber.UnsubscribeToMatrixEvents(diagonalMatrix);

            squareMatrix[0, 0] = 8;
            symmetricMatrix[0, 2] = 15;
            diagonalMatrix[1, 0] = 9;

            Console.ReadKey();
        }
    }

    class SubscriberMatrix
    {
        public void SubscribeToMatrixEvents<T>(SquareMatrix<T> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("Matrix is null");

            matrix.ElementChanges += ProcessingEventsChangeElement;
        }

        public void UnsubscribeToMatrixEvents<T>(SquareMatrix<T> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("Matrix is null");

            matrix.ElementChanges -= ProcessingEventsChangeElement;
        }

        private void ProcessingEventsChangeElement<T>(object sender, MatrixEventArgs<T> e)
        {
            Console.WriteLine("Matrix changed");
            Console.WriteLine("Modified indexes {0} and {1}", e.Row, e.Column);
            Console.WriteLine("Old value - {0}", e.OldValue);
            Console.WriteLine("New value - {0}", e.NewValue);
            Console.WriteLine("Сhanges happened in the class - {0}", sender.ToString());
            Console.WriteLine(new string('*', 20));
        }
    }
}

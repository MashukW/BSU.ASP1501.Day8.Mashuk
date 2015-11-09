using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public abstract class Matrix<T>
    {
        protected T[,] _matrix;

        public int Order { get; protected set; }

        public event EventHandler<MatrixEventArgs<T>> ElementChanges = delegate { };

        public T this[int i, int j]
        {
            get
            {
                if (!CheckIndex(i, j))
                    throw new ArgumentException("invalid index1 or index2");

                return _matrix[i, j];
            }
            set
            {
                if (!CheckIndex(i, j))
                    throw new ArgumentException("invalid index1 or index2");

                T oldValue = _matrix[i, j];
                SetValue(value, i, j);
                OnElementChanges(new MatrixEventArgs<T>(i, j, oldValue, _matrix[i, j]));
            }
        }

        protected virtual void OnElementChanges(MatrixEventArgs<T> e)
        {
            ElementChanges(this, e);
        }

        protected abstract void SetValue(T value, int i, int j);

        private bool CheckIndex(int i, int j)
        {
            if (i < 0 || i >= _matrix.GetLength(0))
                return false;
            if (j < 0 || j >= _matrix.GetLength(1))
                return false;

            return true;
        }
    }
}

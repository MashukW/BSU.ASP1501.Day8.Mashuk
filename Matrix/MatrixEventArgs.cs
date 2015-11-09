﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public sealed class MatrixEventArgs<T> : EventArgs
    {
        public int Row { get; }
        public int Column { get; }
        public T OldValue { get; }
        public T NewValue { get; }

        public MatrixEventArgs(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}

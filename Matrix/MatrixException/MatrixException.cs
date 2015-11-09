using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixException : Exception
    {
        public MatrixException(string message) : base(message) { }

        public MatrixException(string message, Exception ex): base(message, ex) { } 
    }
}

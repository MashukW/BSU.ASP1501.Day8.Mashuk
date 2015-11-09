using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class AddMatrixException : MatrixException
    {
        public AddMatrixException(string message) : base(message) { }
    }
}

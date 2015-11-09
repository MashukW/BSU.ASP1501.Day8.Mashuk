using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrixException:MatrixException
    {
        public SquareMatrixException(string message) : base(message) { }
    }
}

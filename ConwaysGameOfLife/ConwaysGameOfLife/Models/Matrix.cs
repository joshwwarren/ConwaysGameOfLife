using System.Collections;
using System.Collections.Generic;

namespace ConwaysGameOfLife.Models
{
    public class Matrix
    {
        public IEnumerable<Row> Rows { get; set; }

        public IEnumerable<Row> CreateNewMatrix()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Row
    {
        public IEnumerable<Cell> Cells { get; set; }

        public class Cell
        {
        }
    }
}
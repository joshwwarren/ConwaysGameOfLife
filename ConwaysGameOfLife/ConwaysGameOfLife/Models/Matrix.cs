using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife.Models
{
    public class Matrix
    {
        public IEnumerable<Row> Rows { get; set; }

        public IEnumerable<Row> CreateNewMatrix()
        {
            return Enumerable.Range(1, 50)
                .Select(s => new Row
                {
                    Cells = Enumerable.Range(1, 50).Select(z => new Row.Cell())
                });
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
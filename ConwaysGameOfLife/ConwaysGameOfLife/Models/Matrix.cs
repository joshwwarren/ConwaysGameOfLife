using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife.Models
{
    public class Matrix
    {
        public IEnumerable<Row> Rows { get; set; }

        public IEnumerable<Row> CreateNewMatrix(int wall)
        {
            return Enumerable.Range(1, wall)
                .Select(s => new Row
                {
                    Cells = Enumerable.Range(1, wall).Select(z => new Row.Cell())
                });
        }
    }

    public class Row
    {
        public IEnumerable<Cell> Cells { get; set; }

        public class Cell
        {
            public bool IsAlive { get; set; }

            public void Judge(int numberOfNeighbors)
            {
                IsAlive = new[] {2, 3}.Contains(numberOfNeighbors);
            }
        }
    }
}
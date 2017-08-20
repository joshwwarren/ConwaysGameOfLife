using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife.Models
{
    public interface IMatrix
    {
        IEnumerable<Row> CreateNewMatrix();
    }

    public class Matrix
    {
        public IEnumerable<Row> Rows { get; set; }

        public IEnumerable<Row> CreateNewMatrix(int wall)
        {
            return Enumerable.Range(1, wall)
                .Select(s => new Row
                {
                    Cells = Enumerable.Range(1, wall).Select(z => new Row.Cell {IsAlive = IsAliveAtCreation()}).ToList()
                });
        }

        public IEnumerable<Row> JudgeMatrix(IEnumerable<Row> matrix)
        {
            var newMatrix = new List<Row>();
            foreach (var row in matrix)
            {
                var newRow = new Row();
                newRow.Cells = new List<Row.Cell>();
                var rowList = row.Cells.ToList();

                foreach (var cell in rowList)
                {
                    var index = rowList.FindIndex(i => i == cell);
                    var newCell = new Row.Cell
                    {
                        IsAlive = cell.Judge(rowList.Count <= index ? rowList[index + 1].IsAlive ? 1 : 0 : 0)
                    };
                    newRow.Cells.Add(newCell);
                }
                newMatrix.Add(newRow);
            }
            return newMatrix;
        }

        private static bool IsAliveAtCreation()
        {
            return new Random().NextDouble() > 0.5;
        }
    }

    public class Row
    {
        public List<Cell> Cells { get; set; }

        public class Cell
        {
            public bool IsAlive { get; set; }

            public virtual bool Judge(int numberOfNeighbors)
            {
                return new[] {2, 3}.Contains(numberOfNeighbors);
            }
        }
    }
}
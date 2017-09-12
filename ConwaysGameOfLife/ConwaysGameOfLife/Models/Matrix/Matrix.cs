using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife.Models.Matrix
{
    public class Matrix
    {
        private static Random random;
        public List<Row> Rows { get; set; }

        public Matrix CreateNewMatrix(int wall)
        {
            random = new Random();
            return new Matrix
            {
                Rows =
                    Enumerable.Range(1, wall)
                        .Select(s => new Row
                        {
                            Cells = Enumerable.Range(1, wall).Select(z => new Row.Cell {IsAlive = IsAliveAtCreation()})
                                .ToList()
                        }).ToList()
            };
        }

        public Matrix JudgeMatrix(Matrix matrix)
        {
            var newMatrix = new Matrix
            {
                Rows = matrix.Rows.Select(row => new Row
                {
                    Cells = row.Cells.Select(cell =>
                    {
                        var cellIndex = row.Cells.ToList().FindIndex(i => i == cell);
                        var rowIndex = matrix.Rows.ToList().FindIndex(i => i == row);
                        return new Row.Cell
                        {
                            IsAlive = cell.Judge(CalculateLivingNeighbors(matrix, row, cellIndex, rowIndex))
                        };
                    }).ToList()
                }).ToList()
            };

            return newMatrix;
        }

        public virtual int CalculateLivingNeighbors(Matrix matrix, Row row, int cellIndex, int rowIndex)
        {
            return IsTheCellToTheRightAlive(row, cellIndex) +
                   IsTheCellToTheLeftAlive(row, cellIndex) +
                   IsTheCellAboveAlive(matrix, cellIndex, rowIndex) +
                   IsTheCellBelowAlive(matrix, cellIndex, rowIndex) +
                   IsTheCellAboveLeftAlive(matrix, cellIndex, rowIndex) +
                   IsTheCellAboveRightAlive(matrix, cellIndex, rowIndex) +
                   IsTheCellBelowLeftAlive(matrix, cellIndex, rowIndex) +
                   IsTheCellBelowRightAlive(matrix, cellIndex, rowIndex);
        }

        public int IsTheCellBelowRightAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return IsThereARowBelow(matrix, rowIndex) ? IsTheCellToTheRightAlive(matrix.Rows[rowIndex + 1], cellIndex) : 0;
        }

        public int IsTheCellBelowLeftAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return IsThereARowBelow(matrix, rowIndex) ? IsTheCellToTheLeftAlive(matrix.Rows[rowIndex + 1], cellIndex) : 0;
        }

        public int IsTheCellAboveRightAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return IsThereARowAbove(rowIndex) ? IsTheCellToTheRightAlive(matrix.Rows[rowIndex - 1], cellIndex) : 0;
        }

        public int IsTheCellAboveLeftAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return IsThereARowAbove(rowIndex) ? IsTheCellToTheLeftAlive(matrix.Rows[rowIndex - 1], cellIndex) : 0;
        }

        public int IsTheCellBelowAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return IsThereARowBelow(matrix, rowIndex) ? (matrix.Rows[rowIndex + 1].Cells[cellIndex].IsAlive ? 1 : 0) : 0;
        }

        public bool IsThereARowBelow(Matrix matrix, int rowIndex)
        {
            return rowIndex + 1 < matrix.Rows.Count;
        }

        public int IsTheCellAboveAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return IsThereARowAbove(rowIndex) ? (matrix.Rows[rowIndex - 1].Cells[cellIndex].IsAlive ? 1 : 0) : 0;
        }

        public bool IsThereARowAbove(int rowIndex)
        {
            return rowIndex > 0;
        }

        public int IsTheCellToTheLeftAlive(Row row, int cellIndex)
        {
            return cellIndex > 0 ? (row.Cells[cellIndex - 1].IsAlive ? 1 : 0) : 0;
        }

        public int IsTheCellToTheRightAlive(Row row, int cellIndex)
        {
            return cellIndex + 1 < row.Cells.Count ? (row.Cells[cellIndex + 1].IsAlive ? 1 : 0) : 0;
        }

        private static bool IsAliveAtCreation()
        {
            return random.NextDouble() > 0.5;
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife.Models
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

        private int CalculateLivingNeighbors(Matrix matrix, Row row, int cellIndex, int rowIndex)
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

        private int IsTheCellBelowRightAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return matrix.Rows.Count <= rowIndex ? IsTheCellToTheRightAlive(matrix.Rows[rowIndex + 1], cellIndex) : 0;
        }

        private int IsTheCellBelowLeftAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return matrix.Rows.Count <= rowIndex ? IsTheCellToTheLeftAlive(matrix.Rows[rowIndex + 1], cellIndex) : 0;
        }

        private int IsTheCellAboveRightAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return rowIndex > 0 ? IsTheCellToTheRightAlive(matrix.Rows[rowIndex - 1], cellIndex) : 0;
        }

        public int IsTheCellAboveLeftAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return rowIndex > 0 ? IsTheCellToTheLeftAlive(matrix.Rows[rowIndex - 1], cellIndex) : 0;
        }

        public int IsTheCellBelowAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return matrix.Rows.Count <= rowIndex ? (matrix.Rows[rowIndex + 1].Cells[cellIndex].IsAlive ? 1 : 0) : 0;
        }

        public int IsTheCellAboveAlive(Matrix matrix, int cellIndex, int rowIndex)
        {
            return rowIndex > 0 ? (matrix.Rows[rowIndex - 1].Cells[cellIndex].IsAlive ? 1 : 0) : 0;
        }

        private int IsTheCellToTheLeftAlive(Row row, int cellIndex)
        {
            return cellIndex > 0 ? (row.Cells[cellIndex - 1].IsAlive ? 1 : 0) : 0;
        }

        private int IsTheCellToTheRightAlive(Row row, int cellIndex)
        {
            return row.Cells.Count <= cellIndex ? (row.Cells[cellIndex + 1].IsAlive ? 1 : 0) : 0;
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
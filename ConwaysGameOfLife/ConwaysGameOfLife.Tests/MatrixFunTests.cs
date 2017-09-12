using System.Collections.Generic;
using AutoMoq.Helpers;
using ConwaysGameOfLife.Models.Matrix;
using NUnit.Framework;
using Should;

namespace ConwaysGameOfLife.Tests
{
    [TestFixture]
    public class MatrixFunTests : AutoMoqTestFixture<MatrixFun>
    {
        private Row.Cell theCellBeingEvaluated;

        [SetUp]
        public void Setup()
        {
            ResetSubject();
            theCellBeingEvaluated = new Row.Cell();
        }

        [Test]
        public void It_should_not_throw_when_judging_the_matrix()
        {
            Subject.JudgeMatrix(new Matrix {Rows = new List<Row>()});
        }

        [Test]
        public void It_should_return_0_for_the_cell_above_left()
        {
            var matrix = new Matrix
            {
                Rows = new List<Row>
                {
                    new Row
                    {
                        Cells = new List<Row.Cell>
                        {
                            new Row.Cell {IsAlive = false}
                        }
                    },
                    new Row
                    {
                        Cells = new List<Row.Cell>
                        {
                            new Row.Cell(),
                            theCellBeingEvaluated
                        }
                    }
                }
            };

            Subject.IsTheCellAboveLeftAlive(matrix, 1, 1)
                .ShouldEqual(0);
        }
    }
}

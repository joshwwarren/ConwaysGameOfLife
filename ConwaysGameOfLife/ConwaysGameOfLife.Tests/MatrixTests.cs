﻿using System.Collections.Generic;
using System.Linq;
using AutoMoq.Helpers;
using Castle.Components.DictionaryAdapter;
using ConwaysGameOfLife.Models;
using Moq;
using NUnit.Framework;
using Should;

namespace ConwaysGameOfLife.Tests
{
    public class MatrixTests : AutoMoqTestFixture<Matrix>
    {
        [TestFixture]
        public class JudgeMatrix : AutoMoqTestFixture<Matrix>
        {
            private Matrix matrixWithOneCell;

            [SetUp]
            public void Setup()
            {
                ResetSubject();
                matrixWithOneCell = new Matrix
                {
                    Rows = new List<Row>
                    {
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell()
                            }
                        }
                    }
                };
            }

            //[TestCase(true, true, true, false, false, false, false, false, true)]
            //[TestCase(true, true, false, true, false, false, false, false, true)]
            //[TestCase(true, true, false, false, true, false, false, false, true)]
            //[TestCase(true, true, false, false, false, true, false, false, true)]
            //[TestCase(true, true, false, false, false, false, true, false, true)]
            //[TestCase(true, true, false, false, false, false, false, true, true)]
            [TestCase(true, false, true, false, false, false, false, true, true)]
            //[TestCase(true, false, false, true, false, false, false, true, true)]
            //[TestCase(true, false, false, false, true, false, false, true, true)]
            //[TestCase(true, false, false, false, false, true, false, true, true)]
            //[TestCase(true, false, false, false, false, false, true, true, true)]
            public void It_should_judge_cells_with_3_neighbors_live(bool oneone, bool onetwo, bool onethree,
                bool twoone, bool twothree,
                bool threeone, bool threetwo, bool threethree,
                bool expectedResult)
            {
                var theCellBeingEvaluated = new Row.Cell();
                var matrix = new Matrix
                {
                    Rows = new List<Row>
                    {
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell {IsAlive = oneone},
                                new Row.Cell {IsAlive = onetwo},
                                new Row.Cell {IsAlive = onethree}
                            }
                        },
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell {IsAlive = twoone},
                                theCellBeingEvaluated,
                                new Row.Cell {IsAlive = twothree}
                            }
                        },
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell {IsAlive = threeone},
                                new Row.Cell {IsAlive = threetwo},
                                new Row.Cell {IsAlive = threethree}
                            }
                        },
                    }
                };

                var newMatrix = Subject.JudgeMatrix(matrix);

                newMatrix.Rows[1].Cells[1].IsAlive.ShouldEqual(expectedResult);
            }

            [Test]
            public void It_should_return_1_for_the_cell_above_left()
            {
                var theCellBeingEvaluated = new Row.Cell();
                var matrix = new Matrix
                {
                    Rows = new List<Row>
                    {
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell {IsAlive = true}
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
                    .ShouldEqual(1);
            }

            [Test]
            public void It_should_return_0_for_the_cell_above_left()
            {
                var theCellBeingEvaluated = new Row.Cell();
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

            [Test]
            public void It_should_return_0_if_there_is_no_cell_above_left()
            {
                Subject.IsTheCellAboveLeftAlive(matrixWithOneCell, 0, 0)
                    .ShouldEqual(0);
            }

            [Test]
            public void It_should_return_1_for_the_cell_above()
            {
                var theCellBeingEvaluated = new Row.Cell();
                var matrix = new Matrix
                {
                    Rows = new List<Row>
                    {
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell(),
                                new Row.Cell {IsAlive = true}
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

                Subject.IsTheCellAboveAlive(matrix, 1, 1)
                    .ShouldEqual(1);
            }

            [Test]
            public void It_should_return_0_for_the_cell_above()
            {
                var theCellBeingEvaluated = new Row.Cell();
                var matrix = new Matrix
                {
                    Rows = new List<Row>
                    {
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell(),
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

                Subject.IsTheCellAboveAlive(matrix, 1, 1)
                    .ShouldEqual(0);
            }

            [Test]
            public void It_should_return_0_if_there_is_no_cell_above()
            {
                Subject.IsTheCellAboveAlive(matrixWithOneCell, 0, 0)
                    .ShouldEqual(0);
            }

            [Test]
            public void It_should_return_1_for_the_cell_above_right()
            {
                var theCellBeingEvaluated = new Row.Cell();
                var matrix = new Matrix
                {
                    Rows = new List<Row>
                    {
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell(),
                                new Row.Cell(),
                                new Row.Cell {IsAlive = true}
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

                Subject.IsTheCellAboveRightAlive(matrix, 1, 1)
                    .ShouldEqual(1);
            }

            [Test]
            public void It_should_return_0_for_the_cell_above_right()
            {
                var theCellBeingEvaluated = new Row.Cell();
                var matrix = new Matrix
                {
                    Rows = new List<Row>
                    {
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell(),
                                new Row.Cell(),
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

                Subject.IsTheCellAboveRightAlive(matrix, 1, 1)
                    .ShouldEqual(0);
            }

            [Test]
            public void It_should_return_1_for_the_cell_to_the_right()
            {
                Subject.IsTheCellToTheRightAlive(new Row
                    {
                        Cells = new List<Row.Cell>
                        {
                            new Row.Cell(),
                            new Row.Cell{IsAlive = true}
                        }
                    }, 0)
                    .ShouldEqual(1);
            }

            [Test]
            public void It_should_return_0_for_the_cell_to_the_right()
            {
                Subject.IsTheCellToTheRightAlive(new Row
                    {
                        Cells = new List<Row.Cell>
                        {
                            new Row.Cell(),
                            new Row.Cell{IsAlive = false}
                        }
                    }, 0)
                    .ShouldEqual(0);
            }

            [Test]
            public void It_should_return_0_if_there_is_no_cell_to_the_right()
            {
                Subject.IsTheCellToTheRightAlive(new Row
                    {
                        Cells = new List<Row.Cell>
                        {
                            new Row.Cell()
                        }
                    }, 0)
                    .ShouldEqual(0);
            }
        }

        [TestFixture]
        public class CreateNewMatrix : AutoMoqTestFixture<Matrix>
        {
            [SetUp]
            public void Setup()
            {
                ResetSubject();
            }

            [Test]
            public void It_should_create_a_list_50_rows_long()
            {
                Subject.CreateNewMatrix(50).Rows.Count().ShouldEqual(50);
            }

            [Test]
            public void It_should_create_a_list_of_rows_50_cells_wide()
            {
                Subject.CreateNewMatrix(50).Rows.FirstOrDefault().Cells.Count.ShouldEqual(50);
            }
        }
    }
}
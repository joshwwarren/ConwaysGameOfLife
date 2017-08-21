using System.Collections.Generic;
using System.Linq;
using AutoMoq.Helpers;
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
            [SetUp]
            public void Setup()
            {
                ResetSubject();
            }

            [TestCase(true, true, true, false, false, false, false, false, true)]
            [TestCase(true, true, false, true, false, false, false, false, true)]
            [TestCase(true, true, false, false, true, false, false, false, true)]
            [TestCase(true, true, false, false, false, true, false, false, true)]
            [TestCase(true, true, false, false, false, false, true, false, true)]
            [TestCase(true, true, false, false, false, false, false, true, true)]
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
                                new Row.Cell{ IsAlive = oneone},
                                new Row.Cell{ IsAlive = onetwo},
                                new Row.Cell{ IsAlive = onethree}
                            }
                        },
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell{ IsAlive = twoone},
                                theCellBeingEvaluated,
                                new Row.Cell{ IsAlive = twothree}
                            }
                        },
                        new Row
                        {
                            Cells = new List<Row.Cell>
                            {
                                new Row.Cell{ IsAlive = threeone},
                                new Row.Cell{ IsAlive = threetwo},
                                new Row.Cell{ IsAlive = threethree}
                            }
                        },
                    }
                };

                var newMatrix = Subject.JudgeMatrix(matrix);

                newMatrix.Rows[1].Cells[1].IsAlive.ShouldEqual(expectedResult);
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
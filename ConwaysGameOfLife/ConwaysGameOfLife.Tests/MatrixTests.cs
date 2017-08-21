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

            [Test]
            public void It_should_judge_every_cell()
            {
                Subject.JudgeMatrix(Subject.CreateNewMatrix(50));

                Mocked<Row.Cell>()
                    .Verify(x => x.Judge(It.IsAny<int>()), Times.Exactly(2500));
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
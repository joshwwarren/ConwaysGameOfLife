using System.Linq;
using ConwaysGameOfLife.Models;
using Moq;
using NUnit.Framework;
using Should;

namespace ConwaysGameOfLife.Tests
{
    [TestFixture]
    public class InitialLoadTests
    {
        private Matrix matrix;

        [SetUp]
        public void Setup()
        {
            matrix = new Mock<Matrix>().Object;
        }

        [Test]
        public void It_should_create_a_list_of_rows_50_cells_wide()
        {
            matrix.CreateNewMatrix().FirstOrDefault().Cells.Count().ShouldEqual(50);
        }

        [Test]
        public void It_should_create_a_list_50_rows_long()
        {
            
        }
    }
}

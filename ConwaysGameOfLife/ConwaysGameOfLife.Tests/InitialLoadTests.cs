using System.Linq;
using AutoMoq.Helpers;
using ConwaysGameOfLife.Models;
using Moq;
using NUnit.Framework;
using Should;

namespace ConwaysGameOfLife.Tests
{
    [TestFixture]
    public class InitialLoadTests : AutoMoqTestFixture<Matrix>
    {
        [SetUp]
        public void Setup()
        {
           ResetSubject();
        }

        [Test]
        public void It_should_create_a_list_of_rows_50_cells_wide()
        {
            Subject.CreateNewMatrix().FirstOrDefault().Cells.Count().ShouldEqual(50);
        }

        [Test]
        public void It_should_create_a_list_50_rows_long()
        {
            Subject.CreateNewMatrix().Count().ShouldEqual(50);
        }
    }
}

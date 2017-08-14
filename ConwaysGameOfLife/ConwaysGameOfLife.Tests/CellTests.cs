using AutoMoq.Helpers;
using ConwaysGameOfLife.Models;
using NUnit.Framework;
using Should;

namespace ConwaysGameOfLife.Tests
{
    [TestFixture]
    public class CellTests : AutoMoqTestFixture<Row.Cell>
    {
        [SetUp]
        public void Setup()
        {
            ResetSubject();
        }

        [Test]
        public void It_should_die_if_it_has_1_neighbor()
        {
            Subject.Judge(1);
            Subject.IsAlive.ShouldBeFalse();
        }

        [Test]
        public void It_should_die_if_it_has_4_neighbors()
        {
            Subject.Judge(4);
            Subject.IsAlive.ShouldBeFalse();
        }

        [Test]
        public void It_should_die_if_it_has_no_neighbors()
        {
            Subject.Judge(0);
            Subject.IsAlive.ShouldBeFalse();
        }

        [Test]
        public void It_should_populate_if_it_has_3_neighbors()
        {
            Subject.Judge(3);
            Subject.IsAlive.ShouldBeTrue();
        }

        [Test]
        public void It_should_survive_if_it_has_2_neighbors()
        {
            Subject.Judge(2);
            Subject.IsAlive.ShouldBeTrue();
        }

        [Test]
        public void It_should_survive_if_it_has_3_neighbors()
        {
            Subject.Judge(3);
            Subject.IsAlive.ShouldBeTrue();
        }
    }
}
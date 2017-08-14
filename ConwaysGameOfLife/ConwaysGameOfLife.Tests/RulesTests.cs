using AutoMoq.Helpers;
using ConwaysGameOfLife.Models;
using NUnit.Framework;

namespace ConwaysGameOfLife.Tests
{
    [TestFixture]
    public class RulesTests : AutoMoqTestFixture<Matrix>
    {
        [Test]
        public void It_should_die_if_it_has_1_neighbor()
        {
        }

        [Test]
        public void It_should_die_if_it_has_4_neighbors()
        {
        }

        [Test]
        public void It_should_die_if_it_has_no_neighbors()
        {
        }

        [Test]
        public void It_should_populate_if_it_has_3_neighbors()
        {
        }

        [Test]
        public void It_should_survive_if_it_has_2_neighbors()
        {
        }

        [Test]
        public void It_should_survive_if_it_has_3_neighbors()
        {
        }
    }
}
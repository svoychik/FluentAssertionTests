using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace ClassLibrary1
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void CollectionEquals_HaveSameItemsInDifferentOrder()
        {
            var expected = new[] { StatusWorker.Active, StatusWorker.Left, StatusWorker.Locked };
            var actual = new[] { StatusWorker.Active, StatusWorker.Locked, StatusWorker.Left };

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void CollectionEquals_ActualContainsLessElements()
        {
            var expected = new[] { StatusWorker.Active, StatusWorker.Left, StatusWorker.Locked };
            var actual = new[] { StatusWorker.Active, StatusWorker.Locked };

            CollectionAssert.AreEquivalent(expected, actual, "Statuses weren't as expected");
        }

        [Test]
        public void CollectionEquals_ActualIsEmpty()
        {
            var expected = new[] { StatusWorker.Active, StatusWorker.Left, StatusWorker.Locked };
            var actual = new StatusWorker[] { };

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void CollectionEquals_ActualContainsElementsNotExistingInExpectedCollection()
        {
            var expected = new[] { StatusWorker.Active, StatusWorker.Left, StatusWorker.Locked };
            var actual = new StatusWorker[] { StatusWorker.Suspended, StatusWorker.Confirmed, StatusWorker.Locked };

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void FluentAssertionTest()
        {
            var expected = new User
            {
                Age = 10,
                Employer = new Employer()
                {
                    CompanyName = "Amazon",
                    Id = 2
                },
                Money = 100,
                Name = "Name1"
            };
            var actual = new User()
            {
                Age = 10,
                Employer = new Employer()
                {
                    CompanyName = "MS1",
                    Id = 11
                },
                Money = 1011,
                Name = "Name3",

            };

            actual.Should().BeEquivalentTo(expected, opts => opts
                .Including(_ => _.Age)
            );
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Employer Employer { get; set; }
        public decimal Money { get; set; }
    }

    public class Employer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }

    public enum StatusWorker
    {
        Zero = 255,
        Imported = 1,
        Invited = 2,
        Confirmed = 4,
        Active = 8,
        Locked = 16,
        Left = 32,
        Suspended = 64
    }
}

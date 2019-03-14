using FluentAssertions;
using NUnit.Framework;

namespace ClassLibrary1
{
    [TestFixture]
    public class UsersTests
    {
        [Test]
        public void CollectionEquals_HaveSameItemsInDifferentOrder()
        {
            var expected = new[] { UserStatus.Active, UserStatus.Left, UserStatus.Locked };
            var actual = new[] { UserStatus.Active, UserStatus.Locked, UserStatus.Left };

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void CollectionEquals_ActualContainsLessElements()
        {
            var expected = new[] { UserStatus.Active, UserStatus.Left, UserStatus.Locked };
            var actual = new[] { UserStatus.Active, UserStatus.Locked };

            CollectionAssert.AreEquivalent(expected, actual, "Statuses weren't as expected");
        }

        [Test]
        public void CollectionEquals_ActualIsEmpty()
        {
            var expected = new[] { UserStatus.Active, UserStatus.Left, UserStatus.Locked };
            var actual = new UserStatus[] { };

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void CollectionEquals_ActualContainsElementsNotExistingInExpectedCollection()
        {
            var expected = new[] { UserStatus.Active, UserStatus.Left, UserStatus.Locked };
            var actual = new UserStatus[] { UserStatus.Suspended, UserStatus.Confirmed, UserStatus.Locked };

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
}
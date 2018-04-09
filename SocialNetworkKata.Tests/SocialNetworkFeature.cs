using System.Linq;
using System.Security.Policy;
using Moq;
using NUnit.Framework;
using SocialNetworkKata.Domain;

namespace SocialNetworkKata.Tests
{
    [TestFixture]
    public class SocialNetworkFeature
    {

        [Test]
        public void Should_interact_with_followers()
        {
            var userRepository = new UserRepository();
            var outPut = new Mock<IOutput>();
            var socialNetwork = new SocialNetwork(userRepository,outPut.Object);
           

            socialNetwork.Execute("Alice -> I love the weather today");
            var actualPostResult = userRepository.GetUsers().Count();

            Assert.That(actualPostResult, Is.EqualTo(1));

      
            socialNetwork.Execute("Alice");
            var userName = "Alice";
            var actualReadResult = userRepository.GetMessagesFor(userName).Count;

            Assert.That(actualReadResult,Is.EqualTo(1));

            socialNetwork.Execute("Bob -> Good game");
            socialNetwork.Execute("Alice follows Bob");
            var actualFollowedUser = userRepository.GetFollowingUsers(userName).Count;

            Assert.That(actualFollowedUser, Is.EqualTo(1));

            socialNetwork.Execute("Charlie -> Hello all");
            socialNetwork.Execute("Alice follows Charlie");
            socialNetwork.Execute("Alice wall");

            outPut.Verify(x => x.PrintLine("Hello all"));
            outPut.Verify(x => x.PrintLine("Good game"));
            outPut.Verify(x => x.PrintLine("I love the weather today"));



        }
    }
}

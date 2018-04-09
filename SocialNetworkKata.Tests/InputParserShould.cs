using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SocialNetworkKata.Domain;

namespace SocialNetworkKata.Tests
{
    public class InputParserShould
    {
        private InputParser _inputParser;
        private UserRepository _userRepository;

        [SetUp]
        public void SetUp()
        {
            _userRepository = new UserRepository();
            _inputParser = new InputParser(_userRepository);
        }
        [Test]
        public void Parse_Input_String_For_Post_Action()
        {
            var parsedInput = _inputParser.Parse("Alice -> I love the weather today");

            Assert.That(parsedInput,
                Is.EqualTo(new ParsedInput("Alice",InputParser.PostAction, 
                    "I love the weather today", "")));
        }

        [Test]
        public void Parse_Input_String_For_Read_Action()
        {
            var userName = "Alice";
            var parsedInput = _inputParser.Parse(userName);

            Assert.That(parsedInput,
                Is.EqualTo(new ParsedInput(userName, InputParser.ReadAction, "", "")));
        }

        [Test]
        public void Parse_Input_String_For_follow_Action()
        {
            var input = "Alice follows Bob";
            var userName = "Alice";
            var followedUsername = "Bob";
            var parsedInput = _inputParser.Parse(input);

            Assert.That(parsedInput,
                Is.EqualTo(new ParsedInput(userName,InputParser.FollowAction, "", followedUsername)));
        }
    }

}

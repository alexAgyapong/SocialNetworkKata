using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkKata.Domain
{
    public class InputParser
    {
        private UserRepository _userRepository;
        public const string PostAction = "post";
        public const string FollowAction = "follows";
        public const string ReadAction = "read";
        public const string WallAction = "wall";


        public InputParser(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual ParsedInput Parse(string input)
        {
            string[] separatingChars = { "->", "follows", "wall" };
            var inputTokens = new List<string>();
            if (input.Contains("->"))
            {
                inputTokens = input.Split(separatingChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()).ToList();
                return new ParsedInput(inputTokens[0],PostAction , inputTokens[1], "");

            }
            if (input.Contains("follows"))
            {
                inputTokens = input.Split(separatingChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()).ToList(); ;
                return new ParsedInput(inputTokens[0],FollowAction, "",inputTokens[1]);

            }
            if (input.Contains("wall"))
            {
                inputTokens = input.Split(separatingChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim()).ToList(); ;
                return new ParsedInput(inputTokens[0], WallAction, "", "");
            }

            return new ParsedInput(input,ReadAction, "", "");
        }
    }
}
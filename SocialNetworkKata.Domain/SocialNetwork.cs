using System.Collections;
using System.Collections.Generic;

namespace SocialNetworkKata.Domain
{
    public class SocialNetwork
    {
        private readonly UserRepository userRepository;
        private readonly IOutput output;

        public SocialNetwork(UserRepository userRepository, IOutput output)
        {
            this.userRepository = userRepository;
            this.output = output;
        }


        public void Execute(string input)
        {
            var parser = new InputParser(userRepository);
            var parsedInput = parser.Parse(input);
            if (parsedInput.Action.Equals("post"))
            {

                new Post(userRepository, parsedInput).Execute();
            }
            if (parsedInput.Action.Equals("wall"))
            {

                new Wall(userRepository, parsedInput, output).Execute();
            }
            if (parsedInput.Action.Equals("read"))
            {

                new Read(userRepository, parsedInput, output).Execute();
            }
            if (parsedInput.Action.Equals("follows"))
            {

                new Follow(userRepository, parsedInput).Execute();
            }

       
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Domain
{
    public class Read : ICommandAction
    {

        private readonly UserRepository userRepository;
        private readonly ParsedInput parsedInput;
        private readonly IOutput output;

        public Read(UserRepository userRepository,ParsedInput parsedInput, IOutput output)
        {
            this.userRepository = userRepository;
            this.parsedInput = parsedInput;
            this.output = output;
        }
       


        public void Execute()
        {
           var query = userRepository.GetMessagesFor(parsedInput.UserName).Select(x => x);
            foreach (var message in query)
            {
                output.PrintLine(message.ToString());
            }

        }

      
       
    }
}

using System.Linq;

namespace SocialNetworkKata.Domain
{
    public class Wall : ICommandAction
    {
        private UserRepository _userRepository;
        private readonly ParsedInput parsedInput;
        private string userName;
        private IOutput output;



        public Wall(UserRepository userRepository,ParsedInput parsedInput, IOutput output)
        {
            _userRepository = userRepository;
            this.parsedInput = parsedInput;
            this.output = output;

        }

       
        public void Execute()
        {
            var user = _userRepository.GetUser(parsedInput.UserName);

            var followingUsers = user.FollowingUsers.ToList();
            foreach (var following in followingUsers)
            {
                var messages = following.Messages.ToList();
                foreach (var message in messages)
                {
                    output.PrintLine(message.ToString());
                  
                }
            }

            foreach (var userMessage in user.Messages.ToList())
            {
                output.PrintLine(userMessage.ToString());
            }
        }
    }
}
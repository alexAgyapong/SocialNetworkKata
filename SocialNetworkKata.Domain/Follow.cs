namespace SocialNetworkKata.Domain
{
    public class Follow : ICommandAction
    {
        private UserRepository _userRepository;
        private readonly ParsedInput parsedInput;

        
        public Follow(UserRepository userRepository, ParsedInput parsedInput)
        {
            _userRepository = userRepository;
            this.parsedInput = parsedInput;
        }
       
        public void Execute()
        {
            var user = _userRepository.GetUser(parsedInput.UserName);
            var followingUser = _userRepository.GetUser(parsedInput.FollowedUser);
            user.FollowingUsers.Add(followingUser);

        }

        protected bool Equals(Follow other)
        {
            return Equals(_userRepository, other._userRepository) && Equals(parsedInput, other.parsedInput);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Follow) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userRepository != null ? _userRepository.GetHashCode() : 0) * 397) ^ (parsedInput != null ? parsedInput.GetHashCode() : 0);
            }
        }
    }
}
namespace SocialNetworkKata.Domain
{
    public class ParsedInput
    {
        public string UserName { get; }
        public string Action { get; }
        public string Message { get; }
        public string FollowedUser { get; }

        public ParsedInput(string userName, string action, string message, string followedUser)
        {
            UserName = userName;
            Action = action;
            Message = message;
            FollowedUser = followedUser;
        }

        protected bool Equals(ParsedInput other)
        {
            return string.Equals(UserName, other.UserName) 
                   && string.Equals(Action, other.Action)
                   && string.Equals(Message, other.Message) 
                   && string.Equals(FollowedUser, other.FollowedUser);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ParsedInput) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (UserName != null ? UserName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Action != null ? Action.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Message != null ? Message.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FollowedUser != null ? FollowedUser.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
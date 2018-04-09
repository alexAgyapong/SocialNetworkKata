using System.Collections.Generic;

namespace SocialNetworkKata.Domain
{

    public class User
    {
        public IList<Message> Messages { get; }
        public string Username { get; }
        public IList<User> FollowingUsers { get; }

        public User(string username)
        {
            Username = username;
            Messages = new List<Message>();
            FollowingUsers = new List<User>();
        }

    }


}
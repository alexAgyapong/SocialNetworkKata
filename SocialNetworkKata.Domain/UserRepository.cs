using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace SocialNetworkKata.Domain
{
    public class UserRepository
    {
        private readonly List<User> _userRepository;
        public UserRepository()
        {
            _userRepository = new List<User>();
        }
        public void SaveOrUpdate(User user, Message message)
        {
            if (GetUser(user.Username) == null)
            {
                _userRepository.Add(user);
                var currentUser = GetUser(user.Username);
                currentUser.Messages.Add(message);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return new ReadOnlyCollection<User>(_userRepository);
        }

        public User GetUser(string username)
        {
            return _userRepository.Find(x => x.Username == username);
        }
            public List<Message> GetMessagesFor(string userName)
        {
            var currentUser = _userRepository.Find(x => x.Username == userName);
                return currentUser.Messages.ToList();
        }

        public List<User> GetFollowingUsers(string username)
        {
            return GetUser(username).FollowingUsers.ToList();
        }
    }
}
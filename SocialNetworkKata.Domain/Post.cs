using System;
using System.Collections;
using System.Collections.Generic;

namespace SocialNetworkKata.Domain
{
    public class Post : ICommandAction
    {
        private readonly UserRepository userRepository;
        private readonly ParsedInput parsedInput;
       
        public Post(UserRepository userRepository,ParsedInput parsedInput)
        {
            this.userRepository = userRepository;
            this.parsedInput = parsedInput;
        }

       

        public virtual void Execute()
        {
          userRepository.SaveOrUpdate(new User(parsedInput.UserName),new Message(parsedInput.Message));     
        }

        protected bool Equals(Post other)
        {
            return Equals(userRepository, other.userRepository) && Equals(parsedInput, other.parsedInput);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Post) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((userRepository != null ? userRepository.GetHashCode() : 0) * 397) ^ (parsedInput != null ? parsedInput.GetHashCode() : 0);
            }
        }
    }
    }
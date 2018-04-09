using System;

namespace SocialNetworkKata.Domain
{
    internal class ConsoleOutput : IOutput
    {
        public void PrintLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
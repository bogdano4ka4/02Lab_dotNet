using System;

namespace Poberezhets01.Tools.Exceptions
{
    [Serializable]
    public class IllegalDateException : Exception
    {

        public IllegalDateException(string message) : base(message)
        {
        }

       
    }
}

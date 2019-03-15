using System;

namespace Poberezhets01.Tools.Exceptions
{
    [Serializable]
    public class IllegalDateException : Exception
    {

        public IllegalDateException(string birth) : 
            base($"Your date {birth} is incorrect.")
        {
        }

       
    }
}

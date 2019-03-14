﻿using System;

namespace Poberezhets01.Tools.Exceptions
{
    [Serializable]
    public class IllegalEmailException : Exception
    {

        public IllegalEmailException(string message) : base(message)
        {
        }
    }
}
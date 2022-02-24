using System;
using System.Collections.Generic;
using System.Text;

internal class RomanNumberException : Exception
{
    public RomanNumberException(string message) : base(message) { }
}
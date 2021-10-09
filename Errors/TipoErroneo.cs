using System;

namespace App
{
    public class TipoErroneoException : Exception
    {
        public TipoErroneoException() : base() { }
        public TipoErroneoException(string message) : base(message) { }
        public TipoErroneoException(string message, Exception inner) : base(message, inner) { }

    }
}
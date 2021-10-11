using System;

namespace App
{
    public class NombreNuloException : Exception
    {
        public NombreNuloException() : base() { }
        public NombreNuloException(string message) : base(message) { }
        public NombreNuloException(string message, Exception inner) : base(message, inner) { }

    }
}
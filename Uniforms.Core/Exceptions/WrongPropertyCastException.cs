using System;
using System.Collections.Generic;
using System.Text;

namespace Uniforms.Core.Exceptions
{
    public class WrongPropertyCastException : Exception
    {
        public WrongPropertyCastException(string message = null) : base(message)
        {
            
        }
    }
}

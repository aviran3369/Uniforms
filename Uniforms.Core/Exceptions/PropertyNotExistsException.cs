using System;
using System.Collections.Generic;
using System.Text;

namespace Uniforms.Core.Exceptions
{
    public class PropertyNotExistsException : Exception
    {
        public PropertyNotExistsException(string message = null) : base(message)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONode.JSON
{
    public static class Exceptions
    {

        /// <summary>
        /// Attribute exception class
        /// </summary>
        public class AttributeException : Exception
        {
            private const String defaultMessage = "Cast doesn't match Attribute's AttrType.";

            public AttributeException(String message = defaultMessage) :
                base(message)
            {
                // derp
            }
        }

        /// <summary>
        /// Exception for AttrType mismatches
        /// </summary>
        public class AttrTypeMismatchException : Exception
        {
            private const String defaultMessage = "AttrType doesn't match Object type.";

            public AttrTypeMismatchException(String message=defaultMessage) :
                base(message)
            {

            }
        }

    }
}

using System;
using EArray = JSONode.JSON.JArray;

namespace JSONode.JSON
{
    /// <summary>
    /// Used to specify an element attribute's data-type
    /// </summary>
    public enum AttrType
    {
        /// <summary>
        /// String data type
        /// </summary>
        String,
        /// <summary>Literal data type</summary>
        /// <remarks>Numeric types (integers, floats); Hex/Octal (0xff, etc.)</remarks>
        Literal,
        /// <summary>
        /// Boolean data type
        /// </summary>
        Boolean,
        /// <summary>
        /// Element (node)
        /// </summary>
        Element,
        /// <summary>
        /// JArray of elements/nodes
        /// </summary>
        Array
    }

    /// <summary>
    /// AttrType-related extensions for Object and Type classes
    /// </summary>
    /// <see cref="JSONode.JSON.AttrType"/>
    /// <seealso cref="System.Object"/>
    /// <seealso cref="System.Type"/>
    public static class ObjectAttrTypeExtensions {
        /// <summary>
        /// Convert Type to AttrType; extension to Type class
        /// </summary>
        /// <param name="type">Source Type object</param>
        /// <returns>AttrType of Type</returns>
        public static AttrType ToAttrType(this Type type){
           switch(type.Name){
               case "String":
                   return AttrType.String;
               case "JSONode.JSON.JArray":
                   return AttrType.Array;
               case "Boolean":
                   return AttrType.Boolean;
               case "JSONode.JSON.Element":
                   return AttrType.Element;
               default:
                   return AttrType.Literal;
           }
        }

        /// <summary>
        /// Convert Object to AttrType; extension to Object class
        /// </summary>
        /// <param name="srcObject">Extended object</param>
        /// <returns>AttrType for object</returns>
        public static AttrType ToAttrType(this Object srcObject){
            return srcObject.GetType().ToAttrType();
        }

        /// <summary>
        /// Returns JSON-text formatted version of an Object by determining 
        /// its AttrType.
        /// </summary>
        /// <param name="srcObject">Source Object</param>
        /// <returns>Formatted String version of Object's value. If type
        /// is determined to be JArray, Element, or Unknown, null is returned.</returns>
        public static String FormatByAttrType(this Object srcObject){
            String formatted = "Error";
            switch(srcObject.ToAttrType()){
                case AttrType.Array:
                    //throw new Exception("Not implemented.");
                    formatted = null;
                    break;
                case AttrType.Boolean:
                    formatted = ((Boolean)srcObject).ToString().ToLower();
                    break;
                case AttrType.Element:
                    //throw new Exception("Not implemented.");
                    formatted = null;
                    break;
                case AttrType.Literal:
                    formatted = srcObject.ToString();
                    break;
                case AttrType.String:
                    formatted = String.Format("\"{0}\"", srcObject);
                    break;
                //default:
                //    formatted = null;
                //    break;
            }
            return formatted;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EArray = JSONode.JSON.Array;

namespace JSONode.JSON
{
    public class Attribute
    {

        #region [Private Fields]
        private String name;
        private AttrType type;
        private Object value;
        #endregion

        #region [Public Properties]
        /// <summary>
        /// Attribute name
        /// </summary>
        public String Name { get { return name; } set { name = value; } }
        /// <summary>
        /// Attribute value type, read-only
        /// </summary>
        public AttrType Type { get { return this.type; } }
        /// <summary>
        /// Raw, uncast value
        /// </summary>
        public Object RawValue { get { return this.value; } }
        /// <summary>
        /// Get Attribute value (as String); non-string will return null.
        /// </summary>
        public String Value { get { return this.value.FormatByAttrType(); } }
        /// <summary>
        /// Get Attribute value (as Array); non-array value will 
        /// throw AttributeException.
        /// </summary>
        public EArray Value { get { return (EArray)this.value; } }
        /// <summary>Get Attribute value (as Element); non-element value will
        /// throw AttributeException.</summary>
        public Element Value
        {
            get
            {
                Element value = null;
                if (value.ToAttrType() == AttrType.Element)
                {
                    value = (Element)this.value;
                }
                else
                {
                    throw new Exceptions.AttributeException("Attribute is not an Element.");
                }
                return value;
            }
        }
        /// <summary>
        /// Get Attribute value (as Array)
        /// </summary>
        /// <remarks>Will throw an AttributeException if value is not an 
        /// Element</remarks>
        public EArray Value
        {
            get
            {
                EArray value = null;
                if (value.ToAttrType() == AttrType.Array)
                {
                    value = (EArray)this.value;
                }
                else
                {
                    throw new AttributeException("Attribute is not an Array.");
                }
                return value;
            }
        }
        /// <summary>
        /// Update Attribute value with an Object.
        /// Type will also updated.
        /// </summary>
        public Object Value
        {
            set
            {
                this.value = (Object)value;
                this.type = value.ToAttrType();
            }
        }
        #endregion

        /// <summary>
        /// Attribute class constructor
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="value">Attribute value</param>
        public Attribute(String name, Object value)
        {
            this.name = name;
            this.value = value;
            this.type = value.ToAttrType();
        }

    }
}

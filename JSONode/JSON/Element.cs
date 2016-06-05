using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace JSONode.JSON
{
    /// <summary>
    /// Encapsulates data contained within a JSON Element
    /// </summary>
    public class Element
    {

        #region [Private Fields]
        private String name;
        private Collection<Attribute> attributes;
        #endregion

        #region [Public Properties]
        /// <summary>
        /// Name of Element
        /// </summary>
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        /// <summary>
        /// Collection of Element Attributes (read-only)
        /// </summary>
        public Collection<Attribute> Attributes
        {
            get { return this.attributes; }
        }
        #endregion

        /// <summary>
        /// Constructor for Element
        /// </summary>
        /// <param name="name">Element's name</param>
        public Element(String name)
        {
            this.name = name;
            this.attributes = new Collection<Attribute>();
        }

        /// <summary>
        /// Constructor for Element
        /// </summary>
        /// <param name="name">Element's name</param>
        /// <param name="attributes">Array of Attribute objects to initialize Attributes collection with</param>
        public Element(String name, Attribute[] attributes)
        {
            this.name = name;
            this.attributes = new Collection<Attribute>();
            foreach (Attribute attr in attributes)
            {
                this.attributes.Add(attr);
            }
        }

        #region [Attribute Management]
        /// <summary>
        /// Add new attribute
        /// </summary>
        /// <param name="name">Attribute's name</param>
        /// <param name="value">Attribute's value</param>
        public void AddAttribute(String name, Object value)
        {
            this.attributes.Add(new Attribute(name, value));
        }

        /// <summary>
        /// Remove a specific attribute
        /// </summary>
        /// <param name="attribute">Attribute to remove</param>
        public bool RemoveAttribute(Attribute attribute)
        {
            return this.attributes.Remove(attribute);
        }

        /// <summary>
        /// Remove attribute at a given position
        /// </summary>
        /// <param name="position">Zero-based position of attribute to remove</param>
        public void RemoveAttribute(int position)
        {
            this.attributes.RemoveAt(position);
        }
        #endregion

        /// <summary>
        /// Remove all attributes
        /// </summary>
        public void ClearAttributes()
        {
            this.attributes.Clear();
        }

    }


}

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
        private bool isRoot = true;
        private Element parent = null;
        private String name;
        private Collection<Attribute> attributes;
        #endregion

        #region [Public Properties]
        /// <summary>
        /// Element's Parent
        /// </summary>
        public Element Parent
        {
            get { return this.parent; }
            set {
                this.parent = value;
                this.isRoot = (this.parent == null);
            }
        /// <summary>
        /// Indicates if element is a root node
        /// </summary>
        public bool IsRoot
        {
            get { return (parent == null); }
        }
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
        /// <param name="root">If True, Element is considered a root node</param>
        public Element(String name, bool root=false)
        {
            this.isRoot = root;
            this.name = name;
            this.attributes = new Collection<Attribute>();
        }

        /// <summary>
        /// Constructor for Element
        /// </summary>
        /// <param name="name">Element's name</param>
        /// <param name="attributes">Array of Attribute objects to initialize Attributes collection with</param>
        /// <param name="root">If True, Element is considered a root node</param>
        public Element(String name, Attribute[] attributes, bool root=false)
        {
            this.isRoot = root;
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

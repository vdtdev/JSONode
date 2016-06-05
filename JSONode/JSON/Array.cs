using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONode.JSON
{
    public class Array
    {

        #region [Array Item Struct]
        /// <summary>
        /// Struct used to pair Array item values and data types
        /// </summary>
        public struct ArrayItem
        {
            /// <summary>
            /// Value of item (as Object)
            /// </summary>
            public Object Value;
            /// <summary>
            /// Type of item
            /// </summary>
            public AttrType Type;
            /// <summary>
            /// ArrayItem constructor
            /// </summary>
            /// <param name="item">Item value</param>
            public ArrayItem(Object item)
            {
                this.Value = item;
                this.Type = (item == null)? 
                    AttrType.Literal : item.ToAttrType();
            }
            /// <summary>
            /// Static instance of ArrayItem with a null value; use instead of
            /// null when checking if ArrayItem has been initialized;
            /// </summary>
            public static ArrayItem Empty()
            {
                return new ArrayItem(null);
            }
        }
        #endregion

        #region [Private Fields]
        private List<ArrayItem> items;
        #endregion

        #region [Public Properties]
        /// <summary>
        /// All Array items as ArrayItem instances, with pre-determined
        /// AttrType
        /// </summary>
        public ArrayItem[] Items
        {
            get
            {
                return items.ToArray<ArrayItem>();
            }
        }
        #endregion

        /// <summary>
        /// Array constructor
        /// </summary>
        public Array()
        {
            this.items = new List<ArrayItem>();
        }

        #region [Array Item Methods]
        /// <summary>
        /// Add item to Array
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(Object item)
        {
            this.items.Add(new ArrayItem(item));
        }

        /// <summary>
        /// Attempt to remove a specific item from Array
        /// </summary>
        /// <param name="item">Item to try removing</param>
        /// <returns>True if item was found and removed; False otherwise</returns>
        public bool Remove(Object item)
        {
            ArrayItem target = ArrayItem.Empty();
            bool found = true;
            try
            {
                target = items.Where<ArrayItem>(i => i.Value == item).First<ArrayItem>();
            }
            catch (Exception e)
            {
                found = false;
            }

            // consider not found if target value is null
            found = found && (target.Value != null);

            if (found)
            {
                items.Remove(target);
            }
            return found;
        }

        /// <summary>
        /// Remove array item at a certain position
        /// </summary>
        /// <param name="position">Zero-based index of item to remove</param>
        public void RemoveAt(int position)
        {
            this.items.RemoveAt(position);
        }

        /// <summary>
        /// Remove all items from Array
        /// </summary>
        public void Clear()
        {
            this.items.Clear();
        }
        #endregion

        #region [Item Inspection Methods]
        /// <summary>
        /// Array of all items in Array as Objects
        /// </summary>
        public Object[] ItemsAsObjects
        {
            get
            {
                IEnumerable<Object> working =
                    from ArrayItem item in items
                    select item.Value;
                return working.ToArray<Object>();                
            }
        }
        /// <summary>
        /// Ordered array of the types of items in array
        /// </summary>
        public AttrType[] Types
        {
            get
            {
                return (
                    from ArrayItem item in items 
                    select item.Type).ToArray<AttrType>();
            }
        }

        /// <summary>
        /// Get Array containing indexes of all Array items that are of specified non-literal AttrType
        /// </summary>
        /// <remarks>Passing a type other than Element or Array will throw an AttrTypeMismatchException</remarks>
        /// <param name="type">AttrType to filter for; either AttrType.Element or AttrType.Array</param>
        /// <returns>Array containing the indexes of items of the specified type</returns>
        public int[] IndicesOfNonConstantItems(AttrType type)
        {
            AttrType[] accepted = { AttrType.Array, AttrType.Element };
            if (!accepted.Contains(type))
            {
                throw new Exceptions.AttrTypeMismatchException();
            }
            
            return (int[])(
                from ArrayItem item in items
                where (accepted.Contains(item.Type))
                select items.IndexOf(item))
                .ToArray();
        }
        #endregion


    }
}

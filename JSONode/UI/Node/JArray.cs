using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JSONode.UI.Node
{
    /// <summary>
    /// UI Control for displaying JSON Arrays and children
    /// </summary>
    public partial class JArray : UserControl
    {

        private Dictionary<String, Control> contents;
        private JSONode.JSON.JArray source;

        /// <summary>
        /// Children in this Array Control
        /// </summary>
        public Dictionary<String,Control> Children
        {
            get
            {
                return contents;
            }
        }

        #region [Constructors]
        public JArray()
        {
            InitializeComponent();
            contents = new Dictionary<string, Control>();
        }

        public JArray(JSONode.JSON.JArray array)
        {
            InitializeComponent();
            source = array;
        }
        #endregion

        private void RefreshContainerItems()
        {
            int index = 0;
            foreach (String key in contents.Keys)
            {
                Control elem = contents[key];
                if (flowContents.Controls.Count >= (index + 1))
                {
                    if(!flowContents.Controls[index].Equals(elem)){
                        flowContents.Controls.RemoveAt(index);
                        if (!flowContents.Controls.Contains(elem))
                        {
                            flowContents.Controls.Add(elem);
                        }
                        flowContents.Controls.SetChildIndex(elem, index);
                    }
                } else
                {
                    flowContents.Controls.Add(elem);
                }
            }
            
        }


    }
}

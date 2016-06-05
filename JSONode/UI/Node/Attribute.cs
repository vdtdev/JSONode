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
    public partial class Attribute : UserControl
    {

        private String attributeName = "";

        const String QuoteChar = "\"";
        const String ColonChar = ":";

        #region [Public Properties]
        /// <summary>
        /// Attribute Name
        /// </summary>
        public String AttrName
        {
            get
            {
                return attributeName;
            }
            set
            {
                attributeName = FormatAttrName(value,true);
                lblName.Text = FormatAttrName(value);
            }
        }
        #endregion

        public Attribute()
        {
            InitializeComponent();
        }

        #region [Private Helpers]

        /// <summary>
        /// Format string as attribute name, or remove formatting
        /// 
        /// Formatted: <code>"Name":</code>; Unformatted: <code>Name</code>
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="strip">Strip formatting if true, otherwise apply 
        /// missing formatting</param>
        /// <returns>Attribute name with missing formatting applied</returns>
        private String FormatAttrName(String name, bool strip = false)
        {
            name = name.Trim();

            if (strip)
            {
                name = name.Replace(QuoteChar, "").Replace(ColonChar, "");
            }
            else
            {
                bool startQuote, endQuote, colon;

                startQuote = name.StartsWith(QuoteChar);
                colon = name.EndsWith(ColonChar);
                endQuote = (colon ?
                    name.EndsWith(QuoteChar + ColonChar) :
                    name.EndsWith(QuoteChar));

                name = (startQuote ? "" : QuoteChar) + name +
                    (endQuote ? "" : QuoteChar) +
                    (colon ? "" : ColonChar);

            }

            return name;
        }
        #endregion
    }
}

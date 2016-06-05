using JSONode.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JArray = JSONode.JSON.Array;
using JAttribute = JSONode.JSON.Attribute;
using System.IO;
using JsoNet = Newtonsoft.Json;


namespace JSONode.Processing
{
    class JSONReader
    {
        #region [Parse Progress Struct]
        private struct ParseStep
        {
            public enum Location
            {
                Element,
                Array,
                Attribute,
                None
            }
            public JAttribute curAttr;
            public JArray curArray;
            public Element curElem;
            public Location current;
            public Location previous;
            public String nextName;
            public Object nextValue;
            public ParseStep(Element root)
            {
                this.curAttr = null;
                this.curArray = null;
                this.curElem = root;
                this.current = Location.Element;
                this.previous = Location.None;
                this.nextName = null;
                this.nextValue = null;
            }
            /// <summary>
            /// Update tracking location
            /// </summary>
            /// <param name="loc">New location</param>
            /// <param name="sibling">Replace previous with current if true</param>
            public void UpdateLocation(Location loc, bool sibling=false)
            {
                if(!sibling)
                    this.previous = this.current;
                this.current = loc;
            }
        }
        #endregion

        #region [Private Fields/Objects]
        private String fileName = "";
        private String source = "";
        private Element root = null;
        #endregion

        public JSONReader(String fileName)
        {
            this.fileName = fileName;
            this.root = new Element("Root", true);
        }

        public bool Parse()
        {
            if (this.root == null)
            {
                throw new Exception("File not specified.");
            }
            if (this.source == null)
            {
                throw new Exception("File not loaded.");
            }

            bool success = true;

            JsoNet.JsonTextReader reader = new JsoNet.JsonTextReader(new StringReader(this.source));

            ParseStep tracker = new ParseStep(root);

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsoNet.JsonToken.PropertyName:
                        tracker.UpdateLocation(ParseStep.Location.Attribute);
                        tracker.nextName = (String)reader.Value;
                        tracker.curAttr = new JAttribute(tracker.nextName, null);
                        break;
                    case JsoNet.JsonToken.Boolean:
                        if (tracker.current == ParseStep.Location.Attribute)
                        {
                            tracker.curAttr.Value = reader.Value;
                        }
                        if (tracker.current == ParseStep.Location.Array)
                        {
                            tracker.curArray.Add(reader.Value);
                        }
                        break;


                }
            }
            return success;

        }

        #region [Private Methods]
        private bool ReadFile()
        {
            if (this.root == null)
            {
                throw new Exception("File not specified.");
            }
            bool success = true;
            try
            {
                StreamReader stream = new StreamReader(fileName);
                this.source = stream.ReadToEnd();
            }
            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }
        #endregion

    }
}

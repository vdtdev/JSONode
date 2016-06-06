using JSONode.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JArray = JSONode.JSON.JArray;
using JAttribute = JSONode.JSON.Attribute;
using System.IO;
using JsoNet = Newtonsoft.Json;


namespace JSONode.Processing
{
    public class JSONReader
    {


        #region [Parse Progress Struct]
        private struct ParseTracker
        {
            public enum Location { Element, Array, Attribute, None }
            public int curAttr, curArray, curElem;
            public Location curLoc;
            public String nextName;
            public Object nextValue;
            public List<Element> listElem;
            public List<JArray> listArray;
            public List<JAttribute> listAttr;
            public Stack<Location> histLoc;
            public Stack<int> histIndex;

            public ParseTracker(Element root)
            {
                this.nextName = null;
                this.nextValue = null;

                curAttr = curArray = curElem = -1;
                curLoc = Location.Element;

                listElem = new List<Element>();
                listArray = new List<JSON.JArray>();
                listAttr = new List<JSON.Attribute>();

                histLoc = new Stack<Location>();
                histIndex = new Stack<int>();

                listElem.Add(root);
                curElem = listElem.IndexOf(root);
            }
            public Element Element { get { return listElem[curElem]; } }
            public JAttribute Attribute { get { return listAttr[curAttr]; } }
            public JArray Array { get { return listArray[curArray]; } }
            /// <summary>
            /// Change current location and move previous location and index to history
            /// </summary>
            /// <param name="location">New location</param>
            public void UpdateLocation(Location location)
            {
                if(curLoc != Location.None)
                {
                    switch (curLoc)
                    {
                        case Location.Attribute:
                            histIndex.Push(curAttr);
                            break;
                        case Location.Array:
                            histIndex.Push(curArray);
                            break;
                        case Location.Element:
                            histIndex.Push(curElem);
                            break;
                    }
                    histLoc.Push(curLoc);
                }
                curLoc = location;
            }
            /// <summary>
            /// Return to previous location, restoring associated current index
            /// </summary>
            public void PreviousLocation()
            {
                curLoc = histLoc.Pop();
                switch (curLoc)
                {
                    case Location.Array:
                        curArray = histIndex.Pop();
                        break;
                    case Location.Attribute:
                        curAttr = histIndex.Pop();
                        break;
                    case Location.Element:
                        curElem = histIndex.Pop();
                        break;
                }
            }
            public JAttribute StartAttr(String name)
            {
                JAttribute attr = new JAttribute(name, 0);
                listAttr.Add(attr);
                curAttr = listAttr.IndexOf(attr);
                return attr;
            }
            public void FinishAttr()
            {

            }
        }
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
            public Element prevElem;
            public JArray prevArray;
            public JSON.Attribute prevAttr;
            public ParseStep(Element root)
            {
                this.curAttr = null;
                this.curArray = null;
                this.curElem = root;
                this.current = Location.Element;
                this.previous = Location.None;
                this.nextName = null;
                this.nextValue = null;
                this.prevArray = null;
                this.prevElem = null;
                this.prevAttr = null;
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

        #region [Public Properties]
        /// <summary>
        /// Root element of parsed JSON
        /// </summary>
        public Element Document
        {
            get
            {
                return root;
            }
        }
        #endregion

        public JSONReader(String fileName)
        {
            this.fileName = fileName;
            this.root = new Element("Root", true);
            if (!this.ReadFile())
            {
                throw new Exception("File was not successfully loaded.");
            }
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
            ParseTracker track = new ParseTracker(root);

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsoNet.JsonToken.PropertyName:
                        track.UpdateLocation(ParseTracker.Location.Attribute);
                        //track.nextName = (String)reader.Value;
                        track.StartAttr((String)reader.Value);
                        //tracker.UpdateLocation(ParseStep.Location.Attribute);
                        //tracker.nextName = (String)reader.Value;
                        //tracker.curAttr = new JAttribute(tracker.nextName, 0);
                        break;
                    case JsoNet.JsonToken.Boolean:
                        if(track.curLoc == ParseTracker.Location.Attribute)
                        {
                            track.listAttr[track.curAttr].Value = reader.Value;
                            track.Element.Add(track.Attribute);
                            track.curLoc = track.histLoc.Pop();
                        }
                        if(track.curLoc == ParseTracker.Location.Array)
                        {
                            track.Array.Add(reader.Value);
                        }

                        //if (tracker.current == ParseStep.Location.Attribute)
                        //{
                        //    tracker.curAttr.Value = reader.Value;
                        //}
                        //if (tracker.current == ParseStep.Location.Array)
                        //{
                        //    tracker.curArray.Add(reader.Value);
                        //}
                        break;
                    case JsoNet.JsonToken.EndObject:
                        if(track.histLoc.Peek() == ParseTracker.Location.Attribute)
                        {
                            track.Attribute.Value = track.Element;
                            track.curLoc = track.histLoc.Pop();
                        }
                        //tracker.current=tracker.previous;
                        //if (tracker.previous == ParseStep.Location.Element)
                        //{
                        //    tracker.curElem = tracker.prevElem;
                        //}
                        //if (tracker.previous == ParseStep.Location.Array)
                        //{
                        //    tracker.curArray = tracker.prevArray;
                        //}
                        break;
                    case JsoNet.JsonToken.StartObject:
                        track.UpdateLocation(ParseTracker.Location.Element);
                        if(track.histLoc.Peek()== ParseTracker.Location.Attribute)
                        {

                        }
                        tracker.previous = tracker.current;
                        tracker.current = ParseStep.Location.Element;
                        if(tracker.previous == ParseStep.Location.Attribute)
                        {
                            tracker.prevAttr = tracker.curAttr;
                        }
                        break;
                }
            }
            return success;

        }

        #region [Private Methods]
        private bool ReadFile()
        {
            //if (this.root == null)
            //{
            //    throw new Exception("File not specified.");
            //}
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

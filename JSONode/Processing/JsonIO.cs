using System;
using System.IO;
using JsoNet = Newtonsoft.Json;


namespace JSONode.Processing
{
    public class JsonIO
    {

        public static JsoNet.Linq.JObject LoadFile(String fileName)
        {

            StreamReader stream = new StreamReader(fileName);
            JsoNet.Linq.JObject o = JsoNet.Linq.JObject.Parse(stream.ReadToEnd());
            //return o;

            JSON.Element e = new JSON.Element("Root", true);

            foreach(var x in o.Children())
            {
                
            }


        }

    }
}

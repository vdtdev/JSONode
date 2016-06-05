using JSONode.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EArray = JSONode.JSON.Array;
using System.IO;
using JsoNet = Newtonsoft.Json;


namespace JSONode.Processing
{
    class JsonIO
    {

        public static Element LoadFile(String fileName)
        {
            
            JsoNet.JsonTextReader reader = new(new StreamReader(fileName));
            
        }

    }
}

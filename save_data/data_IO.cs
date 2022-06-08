namespace CyberBlight.data_IO
{
    using System.IO;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Formatters.Binary;


    public static class DataIO
    {

        public static void save(object data, object slot)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = File.Create (@$"save_data\saves\{slot}"))
            {
                #pragma warning disable SYSLIB0011
                bf.Serialize(file, data);//dont deserialize data you dont trust;
                #pragma warning restore SYSLIB0001
            }
        }

        public static object load(string slot)
        {
            object data= "nada";
            if(File.Exists(@$"save_data\saves\{slot}"))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream file = File.Open(@$"save_data\saves\{slot}", FileMode.Open))
                    {
                        #pragma warning disable SYSLIB0011
                        data = (object)bf.Deserialize(file);//dont deserialize data you dont trust;
                        #pragma warning restore SYSLIB0001
                    }
                    return data;
                }
                catch(System.Runtime.Serialization.SerializationException)
                {
                    return data;
                }
            }
            return data;
        }

        public static Dictionary<string,string> existing_files(string folderPath)
        {
            Dictionary<string,string> filePaths = Directory.GetFiles(folderPath).
                                                  Select(file => Path.GetFileName(file)).
                                                  ToArray().ToDictionary(file=>file,name=>name);
            filePaths["New Game"]="New Game";
            return filePaths;
        }
    }
}

namespace CyberBlight.data_IO
{
    using System.IO;

    public static class DataIO
    {

        public static void save(object data, object slot)
        {
            
        }

        public static void load(string slot)
        {

        }

        public static Dictionary<string,string> existing_files(string folderPath)
        {
            Dictionary<string,string> filePaths = Directory.GetFiles(folderPath).ToDictionary(file=>file,name=>name);
            filePaths["New Game"]="New Game";
            return filePaths;
        }
    }
}

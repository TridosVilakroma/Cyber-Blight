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
            string[] filePaths = Directory.GetFiles(@$"{folderPath}");
            var saves_dict = new Dictionary<string, string>();
            foreach(var save in filePaths)
            {
                Console.WriteLine(save);
            }


            // saves_dict={i: i for i in listdir(folder)}
            // saves_dict['New Game']= len(saves_dict)+1
            return saves_dict;
        }
    }
}

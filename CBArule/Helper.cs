using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CBArule
{
    static public class Helper
    {

        public static List<char> GetList(List<char> list, string alphaStr)
        {
            if (list == null)
            {
                list = new List<char>();
            }

            if (!string.IsNullOrEmpty(alphaStr))
            {
                foreach( var c in alphaStr)
                {
                    list.Add(c);
                }

            }

            return list;
        }

        public static void WriteToFile(string path, string fileName, string content)
        {
            var filePath = Path.Combine(path, fileName);
            using (var writer = File.CreateText(filePath))
            {
                writer.WriteLine(content); 
            }
        }

        public static void DeleteFiles(string path)
        {
            bool exists = System.IO.Directory.Exists(path);
            if (!exists)
                System.IO.Directory.CreateDirectory(path);
            else
            {
                string[] filePaths = Directory.GetFiles(path);
                foreach (string filePath in filePaths)
                    File.Delete(filePath);
            }
        }


    }
}

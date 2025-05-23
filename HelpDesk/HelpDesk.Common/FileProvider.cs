using System.IO;
using System.Text;

namespace HelpDesk.Common
{
    public static class FileProvider
    {
        public static bool Exists(string fileName)  // переназвал Exists в Exists
        {
            return File.Exists(fileName);
        }

        public static void Write(string fileName, string text)
        {
            using (var writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine(text);
            }
        }

        public static void Delete(string fileName)
        {
            File.Delete(fileName);
        }

        public static string Get(string fileName)
        {
            string text;

            using (var reader = new StreamReader(fileName))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }
    }
}

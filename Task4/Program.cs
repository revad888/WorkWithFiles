using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к файлу: ");
            string path = Console.ReadLine();
            GetData(path);
            
        }

        public static void GetData(string path)
        {
            if (File.Exists(path))
            {
                string s;
                float FloatValue;
                string StringValue;
                int IntValue;
                bool BooleanValue;
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    Console.WriteLine(reader.ReadInt32());
                }
                //Console.WriteLine(s);
            }
        }
    }
}
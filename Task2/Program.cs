using System.IO;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите адрес папки: ");
            string path = Console.ReadLine();
            long size = GetSize(path);
            Console.WriteLine($"Размер папки: {size} байт");
        }

        public static long GetSize(string path)
        {
            long size = 0;
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                try
                {
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        size += file.Length;
                    }
                    DirectoryInfo[] subDirectorys = dir.GetDirectories();
                    foreach (DirectoryInfo d in subDirectorys)
                    {
                        long s = GetSize(d);
                        size += s;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            else
            {
                Console.WriteLine("Папка не существует! Введите корректный путь.");
            }
            return size;

        }
        public static long GetSize(DirectoryInfo dir)
        {
            long size = 0;
            FileInfo[] files = dir.GetFiles();
            try
            {
                foreach (FileInfo file in files)
                {
                    size += file.Length;
                }
                DirectoryInfo[] subDirectorys = dir.GetDirectories();
                foreach (DirectoryInfo d in subDirectorys)
                {
                    long s = GetSize(d);
                    size += s;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return size;
        }
    }

    


}
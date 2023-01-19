using System.Globalization;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к папке");
            string path = Console.ReadLine();
            DirC(path);


        }

        public static void DirC(DirectoryInfo directory)
        {
                    try
                    {
                        bool isEmpty = IsEmpty(directory);
                        if (!isEmpty)
                        {
                            FileInfo[] files = directory.GetFiles();
                            DelFiles(files);
                            DirectoryInfo[] dirs = directory.GetDirectories();
                            foreach (DirectoryInfo dir in dirs)
                            {

                                DirC(dir);

                            }
                            bool isEmptyOut = IsEmpty(directory);
                            if (isEmptyOut) 
                            { 
                                directory.Delete();
                                Console.WriteLine($"Папка {directory.Name} по пути {directory.FullName} была удалена");
                            }
                        }
                        else
                        {   
                             
                            directory.Delete();
                            Console.WriteLine($"Папка {directory.Name} по пути {directory.FullName} была удалена");

                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                

        }

        public static void DirC(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            if (directory.Exists)
            {

                    try
                    {
                        bool isEmpty = IsEmpty(directory);
                        if (!isEmpty)
                        {
                            FileInfo[] files = directory.GetFiles();
                            DelFiles(files);
                            DirectoryInfo[] dirs = directory.GetDirectories();
                            foreach (DirectoryInfo dir in dirs)
                            {

                                DirC(dir);

                            }
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
        }
        public static bool IsEmpty (DirectoryInfo directory)
            {
            DirectoryInfo[] dirs = directory.GetDirectories();
            FileInfo[] files = directory.GetFiles();
            bool IsEmty = (dirs.Length == 0 & files.Length == 0);
            if(IsEmty)
            {
                return true;
            }
            else
            {
                return false;
            }

            } 
        public static void DelFiles(FileInfo[] files)
        {
            DateTime now = DateTime.Now;
            TimeSpan deltaT = TimeSpan.FromMinutes(30);
            foreach (FileInfo f in files)
            {
                if (now - f.LastWriteTime > deltaT)
                {
                    f.Delete();
                    Console.WriteLine($"Файл {f.Name} расположенный по пути {f.Directory.FullName} был удален");
                }
            }
        } 
        
    }
}
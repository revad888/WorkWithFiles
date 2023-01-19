namespace Task3
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

                    }
                }
                else
                {

                    directory.Delete();


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
            long sizeFor = GetSize(path);

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
            long sizeAfter = GetSize(path);
            
            Console.WriteLine($"Исодный размер папки: {sizeFor} байт\nОсвобождено: {sizeFor - sizeAfter} байт\nТекущий рамер папки: {sizeAfter} байт");
        }
        public static bool IsEmpty(DirectoryInfo directory)
        {
            DirectoryInfo[] dirs = directory.GetDirectories();
            FileInfo[] files = directory.GetFiles();
            bool IsEmty = (dirs.Length == 0 & files.Length == 0);
            if (IsEmty)
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
                }
            }
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
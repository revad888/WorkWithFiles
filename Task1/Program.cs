using System.IO;

namespace Task1
{



    //Напишите программу, которая чистит нужную нам папку от файлов  и папок, которые не использовались более 30 минут

    
        //0 баллов: задача решена неверно или отсутствует доступ к репозиторию.
        //2 балла (хорошо): код должен удалять папки рекурсивно (если в нашей папке лежит папка со вложенными файлами, не должно возникнуть проблем с её удалением).
        //4 балла(отлично) : предусмотрена проверка на наличие папки по заданному пути(строчка if directory.Exists); предусмотрена обработка
        //исключений при доступе к папке(блок try-catch, а также логирует исключение в консоль).

    internal class Program
    {
        static void Main(string[] args)
        {
            string p = "C:\\Users\\revad.LAPTOP-GFS75M26\\Desktop\\test";
            
            DirectoryInfo d = new DirectoryInfo(p);
            List<DirectoryInfo> di = FindSubDirectories(d);

            foreach (DirectoryInfo f in di)
            {
                Console.WriteLine(f.FullName);
                
                Console.WriteLine("sadasdasdasdasda");
                Console.ReadKey();
            }
        }

        public void DirClearning (string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            
            if (dir.Exists )
            {

                try
                {

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Директори по введенному пути не существует. Введите путь к существующей директории.");
            }
        }

        public static List<DirectoryInfo> FindSubDirectories (DirectoryInfo directory)
        {
            List<DirectoryInfo> directoryInfos= new List<DirectoryInfo>();

            DirectoryInfo[] dirs = directory.GetDirectories();
            if (dirs.Length > 0)
            {
                foreach (DirectoryInfo d in dirs)
                {
                    List<DirectoryInfo> b = FindSubDirectories(d);
                    foreach (DirectoryInfo f in b)
                    {

                    
                        if (!directoryInfos.Contains(d))
                        {
                            directoryInfos.Add(d);
                        }
                    }
                }
            }
            else
            {
                directoryInfos.Add(directory);
            }
           return directoryInfos;
        }
        
    }
}
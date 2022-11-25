using System.Security.Claims;
using System.IO;
using System.Text;

namespace HomeWork8
/********************************************************************************************************
 ***   2. Создать некое подобие проводника(тотал командера) для работы с файлами и папками.           *** 
 ***   Реализовать создание папок и файлов, копирование, удаление, перемещение/переименование.        ***
 ********************************************************************************************************/
  
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Directory";
            string pathFile = @"C:\Directory\text";
            string newPath = @"C:\Dir";
            string subpath = @"IT\ACD";
            string text = "hello";

            TotalComander TC = new TotalComander();

            TC.CreateDirectory(path);//Создание папки C:\Directory
            File.WriteAllText(pathFile, text);//Создание файла C:\Directory\text
            File.AppendAllText(pathFile, " World"); //дописали в файл
            string fileText = File.ReadAllText(pathFile);
            Console.WriteLine(fileText);

            TC.MoveToDirectory(path, newPath);//переименовывание из C:\Directory в C:\Dir
            TC.CreateDirectory(path);//Создание папки C:\Directory
            TC.CreateDirectory(newPath,subpath);//Создание подпапки ACD в C:\Dir\IT\ACD

            string textFromFile = TC.TextFromFile(@"C:\Dir\text");//читаем из файла
            File.WriteAllText(pathFile, textFromFile); //записываем прочитанное в файл

            Console.WriteLine("Do you want to delete all created folders? Yes or No");
            string answer = Console.ReadLine();
            if (answer == "Yes")
            {
                TC.DeleteDirectory(path);
                TC.DeleteDirectory(newPath);
            }
        }
    }
    class TotalComander
    {
        public string Path { get; set; }
        public string SabPath { get; set; }

        public void CreateDirectory(string Path, string SubPath) 
        {
            EmptyCW();
            DirectoryInfo dirInfo = new DirectoryInfo(Path);
            if (!dirInfo.Exists)
                dirInfo.Create();
            Console.WriteLine($"File name: {dirInfo.Name}");
            Console.WriteLine($"Creation Time: {dirInfo.CreationTime}");
            dirInfo.CreateSubdirectory(SubPath);
        }
        public void CreateDirectory(string Path)
        {
            EmptyCW();
            DirectoryInfo dirInfo = new DirectoryInfo(Path);
            if (!dirInfo.Exists)
                dirInfo.Create();
        }
        public void DeleteDirectory(string Path)
        {
            EmptyCW();
            DirectoryInfo dirInfo = new DirectoryInfo(Path);
            if (dirInfo.Exists)
                dirInfo.Delete(true);//удалить рекурсивно
            else
                Console.WriteLine("Folder not exist!");

        }
        public void MoveToDirectory(string oldPath, string newPath)
        {
            EmptyCW();
            DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
            if (dirInfo.Exists && !Directory.Exists(newPath))
                dirInfo.MoveTo(newPath);
        }
        public void CreateFile(string Path, string text)
        {
            EmptyCW();
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                fs.Write(buffer, 0, buffer.Length);
            }
        }
        public void MoveToFile(string oldPath, string newPath)
        {
            EmptyCW();
            FileInfo fileInfo = new FileInfo(oldPath);
            if (fileInfo.Exists)
                fileInfo.MoveTo(newPath);
        }
        public void CopyToFile(string oldPath, string newPath)
        {
            EmptyCW();
            FileInfo fileInfo = new FileInfo(oldPath);
            if (fileInfo.Exists)
                fileInfo.CopyTo(newPath);
        }
        public string TextFromFile(string Path)
        {
            EmptyCW();
            using (FileStream fs = File.OpenRead(Path))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                return Encoding.Default.GetString(buffer);
            }
        }
        public static void EmptyCW()
        {
            string str = new String('*', 68);
            Console.WriteLine(str);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace lab12
{

    /*
    5. Создать класс XXXFileManager. Набор методов определите 
    самостоятельно. С его помощью выполнить следующие действия: 
        a. Прочитать список файлов и папок заданного диска. Создать 
        директорий XXXInspect, создать текстовый файл 
        xxxdirinfo.txt и сохранить туда  информацию. Создать 
        копию файла и переименовать его. Удалить 
        первоначальный файл. 

        b. Создать еще один директорий XXXFiles. Скопировать в 
        него все файлы с заданным расширением из заданного 
        пользователем директория.  Переместить XXXFiles в 
        XXXInspect. 

        c. Сделайте архив из файлов директория XXXFiles. 
        Разархивируйте его в другой директорий. 
    */

    internal class SIVFileManager
    {
        static public event Action<string> PrintFileManager;
        static public ArrayList GetDirsFromDisk(string diskName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(diskName);
            
            var dirs = dirInfo.GetDirectories();
            var files = dirInfo.GetFiles();

            ArrayList list = new ArrayList();
            list.Add("\nПапки:");
            list.AddRange(dirs);
            list.Add("\nФайлы:");
            list.AddRange(files);

            if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; Получен список директориев диска `{diskName}`");
            
            return list;
        }
        static public void CreateDir(string pathToDir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(pathToDir);
            if (!dirInfo.Exists)
                Directory.CreateDirectory(pathToDir);

            if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; Создан директорий `{dirInfo.Name}`");
        }
        static public void CreateFile(string pathToFile)
        {
            FileInfo fileInfo = new FileInfo(pathToFile);
            if (!File.Exists(pathToFile))
                using (StreamWriter sw = new StreamWriter(pathToFile)) { }

            if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; Создан файл `{fileInfo.Name}`");
        }
        static public void AddTextToFile(string filePath, string text)
        {
            if (File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(text);
                }
                if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; В файл `{filePath}` записана информация");
            }
        }
        static public void CopyFile(string filePath, string copyPath)
        {
            FileInfo file = new FileInfo(filePath);
            FileInfo fileCopy = new FileInfo(copyPath);
            if (file.Exists && !fileCopy.Exists)
            {
                file.CopyTo(copyPath);
                if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; Файл `{filePath}` скопирован по пути `{copyPath}`");
            }
            
        }
        static public void RenameFile(string filePath, string newName)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                string path = "";
                var str = filePath.Split('\\');
                for (int i = 0; i < str.Length - 1; i++)
                {
                    path += str[i];
                    path += '\\';
                }
                if (File.Exists(path))
                {
                    fileInfo.MoveTo(Path.Combine(path, newName));
                    if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; Файл `{filePath}` переименован в `{Path.Combine(path, newName)}`");
                }
            }
        }
        static public void DelFile(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; Удален файл `{filePath}`");
            }
        }
        static public void MoveDir(string oldPath, string newPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
            if (dirInfo.Exists && !Directory.Exists(newPath))
            {
                dirInfo.MoveTo(newPath);
                if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; Директорий `{oldPath}` перемещен в `{newPath}`");
            }
        }
        static public void MakeArchive(string dirPath)
        {
            if (Directory.Exists(dirPath) && !File.Exists(dirPath + ".zip"))
            {
                ZipFile.CreateFromDirectory(dirPath, dirPath + ".zip");
                if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; Создан архив {dirPath + ".zip"}");
            }
        }
        static public void MoveArchive(string olPath, string newPath)
        {
            if (File.Exists(olPath) && !File.Exists(newPath))
            {
                File.Move(olPath, newPath);
                if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; Архив {olPath} перемещен в {newPath}");
            }
        }
        static public void DisArchive(string archPath, string disArchPath)
        {
            if (File.Exists(archPath))
            {
                ZipFile.ExtractToDirectory(archPath, disArchPath);
                if (PrintFileManager != null) PrintFileManager($"{DateTime.Now}; Архив {archPath} распакован в {disArchPath}");
            }
        }

    }
}

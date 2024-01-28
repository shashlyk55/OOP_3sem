using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{

    /*
     4. Создать класс XXXDirInfo c методами для вывода информации о конкретном директории 
        a. Количестве файлов 
        b. Время создания 
        c. Количестве поддиректориев 
        d. Список родительских директориев 
        e. Продемонстрируйте работу класса 
     */

    internal class SIVDirInfo
    {
        static public event Action<string> PrintDirInfo;
        static public int GetFileCount(string dir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (dirInfo.Exists)
            {
                if (PrintDirInfo != null) PrintDirInfo($"{DateTime.Now}; Получено количество файлов в директории {dir}");
                return dirInfo.EnumerateFiles().Count();
            }
            else throw new Exception("Каталог не найден");
        }
        static public DateTime GetCreateTime(string dir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (dirInfo.Exists)
            {
                if (PrintDirInfo != null) PrintDirInfo($"{DateTime.Now}; Получена дата создания директория {dir}");
                return dirInfo.CreationTime;
            }
            else throw new Exception("Каталог не найден");
        }
        static public int GetSubdirsCount(string dir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if(dirInfo.Exists)
            {
                if (PrintDirInfo != null) PrintDirInfo($"{DateTime.Now}; Получено количество поддиреториев в директории {dir}");
                return dirInfo.EnumerateDirectories().Count();
            }
            else throw new Exception("Каталог не найден");
        }
        static public IEnumerable<DirectoryInfo> GetParentDirs(string dir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            var parentDirs = new List<DirectoryInfo>();
            if (dirInfo.Exists)
            {
                while (dirInfo.Parent != null)
                {
                    dirInfo = dirInfo.Parent;
                    parentDirs.Add(dirInfo);
                }
                if (PrintDirInfo != null) PrintDirInfo($"{DateTime.Now}; Получен список родитеских директориев директория {dir}");
                return parentDirs;
            }
            else throw new Exception("Каталог не найден");
        }
    }
}

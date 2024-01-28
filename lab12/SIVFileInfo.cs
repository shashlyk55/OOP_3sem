using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{

    /*
     3. Создать класс XXXFileInfo c методами для вывода информации о конкретном файле 
        a. Полный путь 
        b. Размер, расширение, имя 
        c. Дата создания, изменения 
        d. Продемонстрируйте работу класса 
    */

    internal class SIVFileInfo
    {
        static public Action<string> PrintFileInfo;
        //static public string GetFilePath(string file) => Path.GetFullPath(file);
        static public string GetFilePath(string file)
        {
            if (PrintFileInfo != null) PrintFileInfo($"{DateTime.Now}; Получен путь к файлу {file}");
            return Path.GetFullPath(file);
        }
        static public string GetFileInfo(string file)
        {
            FileInfo fileInfo = new FileInfo(GetFilePath(file));
            if (PrintFileInfo != null) PrintFileInfo($"{DateTime.Now}; Получена информация о размере и расширении файла {file}");
            return $"Size: {fileInfo.Length} byte\nExtension: {fileInfo.Extension}\nName: {fileInfo.Name}\n";
        }
        static public string CreateAndChangeDate(string file)
        {
            FileInfo fileInfo = new FileInfo(GetFilePath(file));
            if (PrintFileInfo != null) PrintFileInfo($"{DateTime.Now}; Получена информация о создании и изменении файла {file}");
            return $"Create date: {fileInfo.CreationTime}\nChange date: {fileInfo.LastWriteTime}\n";
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{

    /*
     № 12 Работа с потоковыми классами и файловой системой 

        Каждый класс в данном проекте должен начинаться (Префикс) с ваших 
        инициалов ФИО (AVF, JK,….). Предусмотреть обработку ошибок. 

    7. Обязательно обрабатывайте возможные ошибки. В случае с потоками 
    необходимо использовать конструкцию using. Если необходимо 
    «построить» путь, то следует использовать методы класса Path 
    */

    internal class Program
    {
        static void Main()
        {
            StreamWriter writer = new StreamWriter("D:\\sivlogfile.txt", true);

            SIVFileManager.PrintFileManager += (s) => writer.WriteLine(s);
            SIVFileInfo.PrintFileInfo += (s) => writer.WriteLine(s);
            SIVDiskInfo.PrintDiskInf += (s) => writer.WriteLine(s);
            SIVDirInfo.PrintDirInfo += (s) => writer.WriteLine(s);

            try
            {
                Console.WriteLine("Информация о диске");
                Console.WriteLine(SIVDiskInfo.GetFreeSize());
                Console.WriteLine(SIVDiskInfo.GetFileSystem());
                Console.WriteLine(SIVDiskInfo.GetDisksInfo());

                Console.WriteLine("\nИнформация о файле");
                Console.WriteLine(SIVFileInfo.GetFilePath("text.txt"));
                Console.WriteLine(SIVFileInfo.GetFileInfo("text.txt"));
                Console.WriteLine(SIVFileInfo.CreateAndChangeDate("text.txt"));

                Console.WriteLine("\nИнформация о директории");
                Console.WriteLine("Файлов в папке: " + SIVDirInfo.GetFileCount("D:\\Labs_C#\\Lab11\\lab11"));
                Console.WriteLine("Подпапок в папке: " + SIVDirInfo.GetSubdirsCount("D:\\Labs_C#\\Lab11\\lab11"));
                Console.WriteLine("Время создания папки: " + SIVDirInfo.GetCreateTime("D:\\Labs_C#\\Lab11\\lab11"));

                var parentsDirs = SIVDirInfo.GetParentDirs("D:\\Labs_C#\\Lab11\\lab11");
                Console.WriteLine("Список родительских директориев: ");
                foreach (var parent in parentsDirs)
                    Console.WriteLine(parent);
            }
            catch(Exception ex)
            {
                SIVFileManager.PrintFileManager -= (s) => writer.WriteLine(s);
                SIVFileInfo.PrintFileInfo -= (s) => writer.WriteLine(s);
                SIVDiskInfo.PrintDiskInf -= (s) => writer.WriteLine(s);
                SIVDirInfo.PrintDirInfo -= (s) => writer.WriteLine(s);

                writer.Close();
                writer.Dispose();

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            try
            {
                Console.WriteLine("Менеджер файлов");

                ArrayList dirList = SIVFileManager.GetDirsFromDisk("D:\\");
                foreach (var item in dirList)
                    Console.WriteLine(item);

                Console.WriteLine();
                SIVFileManager.CreateDir("D:\\SIVInspect");
                SIVFileManager.CreateFile("D:\\SIVInspect\\sivdirinfo.txt");

            
                SIVFileManager.AddTextToFile("D:\\SIVInspect\\sivdirinfo.txt","1111");
            
                SIVFileManager.CopyFile("D:\\SIVInspect\\sivdirinfo.txt", "D:\\SIVInspect\\text.txt");
            
                //SIVFileManager.RenameFile("D:\\SIVInspect\\sivdirinfo.txt", "text.txt");
            
                SIVFileManager.DelFile("D:\\SIVInspect\\sivdirinfo.txt");

            }
            catch (Exception ex)
            {
                SIVFileManager.PrintFileManager -= (s) => writer.WriteLine(s);
                SIVFileInfo.PrintFileInfo -= (s) => writer.WriteLine(s);
                SIVDiskInfo.PrintDiskInf -= (s) => writer.WriteLine(s);
                SIVDirInfo.PrintDirInfo -= (s) => writer.WriteLine(s);

                writer.Close();
                writer.Dispose();

                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine();

            try
            {
                SIVFileManager.CreateDir("D:\\SIVFiles");

                var files = Directory.GetFiles("D:\\Labs_C#\\Lab12\\lab12", "*.js");
                string path;
                foreach (var file in files)
                {
                    var temp = file.Split('\\');
                    path = temp.Last();
                    FileInfo fileInfo = new FileInfo(Path.Combine("D:\\SIVFiles", path));

                    if (!fileInfo.Exists)
                        SIVFileManager.CopyFile(file, Path.Combine("D:\\SIVFiles", path));
                }
                SIVFileManager.MoveDir("D:\\SIVFiles", "D:\\SIVInspect\\SIVFiles");

            }
            catch (Exception ex)
            {
                SIVFileManager.PrintFileManager -= (s) => writer.WriteLine(s);
                SIVFileInfo.PrintFileInfo -= (s) => writer.WriteLine(s);
                SIVDiskInfo.PrintDiskInf -= (s) => writer.WriteLine(s);
                SIVDirInfo.PrintDirInfo -= (s) => writer.WriteLine(s);

                writer.Close();
                writer.Dispose();

                Console.WriteLine(ex.Message);
            }

            try
            {
                SIVFileManager.MakeArchive("D:\\SIVInspect\\SIVFiles");
                SIVFileManager.CreateDir("D:\\SIVArchives");
                SIVFileManager.MoveArchive("D:\\SIVInspect\\SIVFiles.zip", "D:\\SIVArchives\\SIVFiles.zip");
                SIVFileManager.DisArchive("D:\\SIVArchives\\SIVFiles.zip", "D:\\SIVArchives");

            }
            catch (Exception ex)
            {
                SIVFileManager.PrintFileManager -= (s) => writer.WriteLine(s);
                SIVFileInfo.PrintFileInfo -= (s) => writer.WriteLine(s);
                SIVDiskInfo.PrintDiskInf -= (s) => writer.WriteLine(s);
                SIVDirInfo.PrintDirInfo -= (s) => writer.WriteLine(s);

                writer.Close();
                writer.Dispose();

                Console.WriteLine(ex.Message);
            }

            SIVFileManager.PrintFileManager -= (s) => writer.WriteLine(s);
            SIVFileInfo.PrintFileInfo -= (s) => writer.WriteLine(s);
            SIVDiskInfo.PrintDiskInf -= (s) => writer.WriteLine(s);
            SIVDirInfo.PrintDirInfo -= (s) => writer.WriteLine(s);

            writer.Close();
            writer.Dispose();

            Console.ReadKey();
            Console.Clear();


            try
            {
                Console.WriteLine($"Количество записей в log-файле: {SIVLog.GetCountOfNotes("D:\\sivlogfile.txt")}");
                Console.WriteLine(SIVLog.GetInfoForPeriod("D:\\sivlogfile.txt", "08.11.2023", "10.11.2023"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}

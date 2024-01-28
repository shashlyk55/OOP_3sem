using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{

    /*
     2. Создать класс XXXDiskInfo c методами для вывода информации о 
        a. свободном месте на диске 
        b. Файловой системе 
        c. Для каждого существующего диска - имя, объем, доступный 
        объем, метка тома. 
        d. Продемонстрируйте работу класса 
     */

    internal class SIVDiskInfo
    {
        static public event Action<string> PrintDiskInf;
        static public string GetFreeSize()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string info = "";
            foreach (var d in drives)
                info += $"Disk: {d.Name}: {d.TotalFreeSpace / Math.Pow(10, 9)} Gb\n";
            if (PrintDiskInf != null) PrintDiskInf($"{DateTime.Now}; Получена информация о свободном месте на дисках");
            return info;
        }
        static public string GetFileSystem()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string system = "";
            foreach(var d in drives)
                system += $"Disk: {d.Name}: file system: {d.DriveFormat}\n";
            if (PrintDiskInf != null) PrintDiskInf($"{DateTime.Now}; Получена информация о файловой системе дисков");
            return system;
        }
        static public string GetDisksInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string info = "";
            foreach (var d in drives)
                info += $"Disk: {d.Name} \nVolume: {d.TotalSize / Math.Pow(10, 9)} Gb \nFreeVolume: {d.TotalFreeSpace / Math.Pow(10, 9)} Gb \nVolume label: {d.VolumeLabel}\n";
            if (PrintDiskInf != null) PrintDiskInf($"{DateTime.Now}; Получена информация о объеме дисков");
            return info;
        }
    }
}

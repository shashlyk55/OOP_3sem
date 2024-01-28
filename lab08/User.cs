using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Создать класс Пользователь с событиями upgrade и work. В main 
создать некоторое количество объектов (ПО). Подпишите объекты 
на события произвольным образом. Реакция на события  может 
быть следующая: обновление версии, вывод сообщений и т.п.  
Проверить результаты изменения объектов после наступления 
событий. */

namespace lab08
{
    internal class User //пользователь приложения
    {
        private float _bankAccount;   // накопленная прибыбь от приложения
        private float _version;
        public float BankAccount { get; }
        public float Version { get; }

        public delegate void AccountHandler(string message);

        public event AccountHandler Upgraded;
        public event AccountHandler Working;
        public event AccountHandler Worked;
        public event AccountHandler Withdrawn;

        public User(float version = 1.0f, float bankAccount = 0)
        {
            if (bankAccount > 0 && version > 0)
            {
                _bankAccount = bankAccount;
                _version = version;
            }
            else throw new Exception("Версия приложения и счет в банке не могут быть отрицательными!\n");
        }
        public void UpgradeApp(float versionCount)
        {
            if(versionCount > 0)
            {
                _version += versionCount;
                if (Upgraded != null) 
                    Upgraded($"Приложение обновлено до версии {_version}\n");
                else throw new Exception("Событие пустое!\n");
            }
        }
        public void WorkApp(float profit)
        {
            if (profit > 0)
            {
                if (Working != null) 
                    Working($"Приложение работает и приносит прибыль\n");
                else throw new Exception("Событие пустое!\n");

                _bankAccount += profit * Version;

                if (Worked != null) 
                    Worked($"За время работы приложения было заработано {profit}\n");
                else throw new Exception("Событие пустое!\n");
            }
        }
        public void Withdraw(float sum)     // вывод денег со счета
        {
            if(_bankAccount > sum)
            {
                _bankAccount -= sum;
                Withdrawn($"Со счета выведено {sum}\n");
            }    
            else
            {
                if (Withdrawn != null)
                    Withdrawn($"Недостаточно средств на счете для вывода\n");
                else throw new Exception("Событие пустое!\n");
            }
        }
    }
}

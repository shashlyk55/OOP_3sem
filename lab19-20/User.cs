using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab19_20
{
    public class User
    {
        public string UserName { get; set; }
        public int Money { get; set; }
        public Edition wantSubscribe { get; set; }
        public int Debt { get; set; }
        public User(string userName, int money)
        {
            UserName = userName;
            Money = money;
        }
        // Pattern Prototype 
        private User(User donor)
        {
            this.UserName = donor.UserName;
            this.Money = donor.Money;
            this.Debt = donor.Debt;
        }
        public User Clone() => new User(this);
        ////
        public override string ToString()
        {
            return $"Name: {UserName} money: {Money} debt: {Debt}";
        }
        public void Subscribe(Edition edition)
        {
            wantSubscribe = edition;
            if (!edition.userList.Contains(this))
            {
                SendSubscriptionRequest(edition);
                edition.SendPaymentRequest(this);
                this.Pay(edition);
                edition.RegisterUser(this);
            }
            else Console.WriteLine($"У пользователя {UserName} уже офрмлена подписка на издание {edition.Name}");
        }
        internal void SendSubscriptionRequest(Edition edition)
        {
            wantSubscribe = edition;
            if (!edition.debtUserList.Contains(this))
            {
                edition.debtUserList.Add(this);
            }
        }
        internal void Pay(Edition edition)
        {
            if (Money >= edition.Cost)
            {
                Money -= edition.Cost;
            }
            else
            {
                Console.WriteLine($"У пользователя {UserName} недостаточно средств для оформления подписки");
            }
        }
        public void Unsubscrabing(Edition edition)
        {
            if (edition.userList.Contains(this))
            {
                edition.userList.Remove(this);
                Console.WriteLine($"Пользователь {UserName} отказался от подписки");
            }
            else Console.WriteLine($"Пользователь {UserName} не был подписан на издательство {edition.Name}");
        }
        public void ShowMaterials(Edition edition)
        {
            if (edition.userList.Contains(this))
            {
                foreach (var article in edition.articleList)
                    Console.WriteLine(article);
                foreach (var magazine in edition.magazineList)
                    Console.WriteLine(magazine);
            }
            else Console.WriteLine($"Пользователь {UserName} не подписан на издательство {edition.Name}");
        }
    }
}

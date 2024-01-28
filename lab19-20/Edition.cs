using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lab19_20
{
    //// Abstract Factory
    public interface IRelease
    {
        void Release(Edition edition);
    }
    public class Article : IRelease
    {
        public string Topic { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public Article(string topic, string title)
        {
            Topic = topic;
            Title = title;
            Created = DateTime.Now;
        }
        public override string ToString() => $"Date:{Created} Topic:{Topic}. {Title}";
        public void Release(Edition edition)
        {
            edition.articleList.Add(this);
            Console.WriteLine("Новая статья");
        }
    }
    public class Magazine : IRelease
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public List<Article> articlesInMagazine = new List<Article>();
        public Magazine() { }
        public Magazine(string name, string content)
        {
            Name = name;
            Content = content;
            Created = DateTime.Now;
        }
        public Magazine(string name, string content, params Article[] articles)
        {
            Name = name;
            Content = content;
            Created = DateTime.Now;
            articlesInMagazine.AddRange(articles);
        }
        public override string ToString()
        {
            if (articlesInMagazine.Count == 0)
                return $"Date:{Created} Name:{Name}. {Content}";
            string str = "";
            str += $"Date:{Created} Name:{Name}. {Content}";
            str += '\n';
            foreach (var article in articlesInMagazine)
            {
                str += article;
                str += '\n';
            }
            return str;
        }
        public void Release(Edition edition)
        {
            edition.magazineList.Add(this);
            Console.WriteLine("Новая газета");
        }
    }
    public interface IAdministrator
    {
        // For Abstract Factory Pattern
        IRelease CreateNote(string topic, string title);
        IRelease CreateMagazine(string name, string content);
        IRelease CreateMagazine(string name, string content, params Article[] articles);
        // For Builder Pattern
        void CreateNotes(params Article[] articles);
        Magazine GetMagazine();
    }
    public class Administrator : IAdministrator
    {
        // Builder Pattern
        private string name;
        private Edition edition;
        private Magazine magazine;
        public Administrator(string name, Edition edition)
        {
            this.name = name;
            this.edition = edition;
        }
        public Administrator(string name, Edition edition, Magazine magazine)
        {
            this.name = name;
            this.edition = edition;
            this.magazine = magazine;
        }
        public void CreateArticle(string name, string title)
        {
            magazine.articlesInMagazine.Add(new Article(name, title));
        }
        public Magazine GetMagazine() => magazine;

        public void CreateNotes(params Article[] articles) => magazine.articlesInMagazine.AddRange(articles);
        public IRelease CreateNote(string topic, string title) => new Article(topic, title);
        public IRelease CreateMagazine(string name, string content) => magazine = new Magazine(name, content);
        public IRelease CreateMagazine(string name, string content, params Article[] articles) => magazine = new Magazine(name, content, articles);
        public void DeleteArticle(Article article, Edition edition)
        {
            edition.articleList.Remove(article);
        }
        public void AddMagazine(Magazine magazine, Edition edition)
        {
            edition.magazineList.Add(magazine);
        }
        public void DeleteArticle(Magazine magazine, Edition edition)
        {
            edition.magazineList.Remove(magazine);
        }
    }

    class Director
    {
        private IAdministrator admin;
        public Director(IAdministrator admin) => this.admin = admin;
        public void SetAdministrator(IAdministrator admin) => this.admin = admin;
        public Magazine MountEmptyMagazine(string name, string content)
        {
            admin.CreateMagazine(name, content);
            return admin.GetMagazine();
        }
        public Magazine MountFullMagazine(string name, string content, params Article[] articles)
        {
            admin.CreateMagazine(name, content);
            admin.CreateNotes(articles);
            return admin.GetMagazine();
        }
    }
    public sealed class Edition
    {
        //// Pattern Singleton
        public string Name { get; }
        private static Edition edition;
        private static readonly object Locker = new object();
        private Edition(string name) => Name = name;
        public static Edition GetEdition(string name)
        {
            if (edition == null)
                lock (Locker)
                    if (edition == null)
                        edition = new Edition(name);
            return edition;
        }
        /*public string Name { get; }
        private static Edition edition;
        private Edition(string name)
        {
            Name = name;
        }
        public static Edition GetEdition(string name)
        {
            if (edition == null)
                edition = new Edition(name);
            return edition;
        }*/

        public List<User> userList = new List<User>();
        public List<User> debtUserList = new List<User>();
        public List<Article> articleList = new List<Article>();
        public List<Magazine> magazineList = new List<Magazine>();

        public readonly int Cost = 100;

        internal void SendPaymentRequest(User user)
        {
            if (debtUserList.Contains(user))
            {
                user.Debt += Cost;
            }
            else
            {
                Console.WriteLine("Данный пользователь не отправлял запрос на подписку\n");
            }
        }
        public void RegisterUser(User user)
        {
            if (user.wantSubscribe == this && debtUserList.Contains(user))
            {
                debtUserList.Remove(user);
                userList.Add(user);
                Console.WriteLine($"Пользователь {user.UserName} поддписался на издание {Name}");
            }
            else Console.WriteLine("Что-то пошло не так");
        }
    }
}


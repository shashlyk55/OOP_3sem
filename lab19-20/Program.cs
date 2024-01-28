using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab19_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Порождающие паттерны");

            User user1 = new User("Vova", 250);
            User user2 = new User("Bob", 50);
            User user3 = new User("Paul", 500);

            // Pattern Singleton
            var edition = Edition.GetEdition("JohnInterprise");

            var admin = new Administrator("John", edition);

            // Pattern Abstract Factory
            IRelease articleEdition = admin.CreateNote("News", "some news");
            articleEdition.Release(edition);
            IRelease magazineEdition = admin.CreateMagazine("NY Today", "ny news");
            magazineEdition.Release(edition);

            Console.WriteLine();

            user1.Subscribe(edition);
            user1.Subscribe(edition);

            user2.ShowMaterials(edition);
            user1.ShowMaterials(edition);
            Console.WriteLine();

            // Pattern Builder
            try
            {
                IAdministrator administrator = new Administrator("Bob", edition, new Magazine());
                Director director = new Director(administrator);

                Magazine fullMagazine = director.MountFullMagazine("RusNews", "any content", new Article("Old news", "old news"), new Article("Today news", "today news"), new Article("New news", "new news"));
                Console.WriteLine(fullMagazine);

                Magazine emptyMagazine = director.MountEmptyMagazine("BelNews", "any content");
                Console.WriteLine(emptyMagazine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

            // Pattern Prototype
            User userDonor = new User("Carl", 333);
            User userClone = userDonor.Clone();

            Console.WriteLine(userDonor);
            Console.WriteLine(userClone);

            Console.WriteLine();
            Console.WriteLine();
            //////////////

            Console.WriteLine("Структурные паттерны");

            Gazeta gazeta1 = new Gazeta("текст");
            gazeta1.Write("any text");

            // Pattern Decorator
            IGazeta gazeta = new Gazeta("какой-то текст");
            gazeta.Read();

            Console.WriteLine();

            IGazeta gazetaWithDecor = new GazetaWithDecor(gazeta);
            gazetaWithDecor.Read();

            Console.WriteLine("Паттерны поведения\n");

            // Pattern Memento
            Gazeta gazetaEx = new Gazeta("начальный текст");
            EditionHistory usingHistory = new EditionHistory();

            Console.WriteLine(gazetaEx.Text);
            usingHistory.history.Push(gazetaEx.SaveState());

            gazetaEx.Write(" + еще какой-то текст");
            Console.WriteLine(gazetaEx.Text);

            gazetaEx.RestoreState(usingHistory.history.Pop());
            Console.WriteLine(gazetaEx.Text);
            Console.WriteLine();

            // Pattern Template Method
            PaperPlane plane = new PaperPlane();
            PaperShip ship = new PaperShip();

            plane.TemplateMethod();
            Console.WriteLine();
            ship.TemplateMethod();
            Console.WriteLine();

            //Pattern Strategy
            IStrategy pl = new PaperPlane();
            IStrategy sh = new PaperShip();
            Context c = new Context(pl);
            c.Execute();


        }
    }
}

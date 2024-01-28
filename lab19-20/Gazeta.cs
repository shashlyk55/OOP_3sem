using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab19_20
{
    // Pattern Decorator
    public class GazetaDecorator : IGazeta
    {
        protected readonly IGazeta gazeta;
        public GazetaDecorator(IGazeta gazeta)
        {
            this.gazeta = gazeta;
        }
        public virtual string Text
        {
            get { return gazeta.Text; }
            set { gazeta.Text = value; }
        }
        public virtual void Read()
        {
            Console.WriteLine("Читаю газету");
            Console.WriteLine($"Содержимое: {Text}");
        }

        public void Write(string text)
        {
            this.Text = text;
        }
        public void Origami()
        {
            Console.WriteLine("Сделали кораблик из газеты");
        }
    }

    // Pattern Adapter
    public interface IGazeta
    {
        string Text { get; set; }
        void Read();
        void Write(string text);
    }

    internal class Gazeta : Magazine, IGazeta
    {
        public string Text { get; set; }
        public Gazeta(string text) { Text = text; }
        public void Read()
        {
            Console.WriteLine("Читаю газету");
            Console.WriteLine($"Содержимое: {Text}");
        }

        public void Write(string text)
        {
            this.Text += text;
        }
        // сохранение состояния
        public GazetaMemento SaveState()
        {
            Console.WriteLine($"Сохранение информации в газете: {Text}");
            return new GazetaMemento(Text);
        }
        // восстановление состояния
        public void RestoreState(GazetaMemento memento)
        {
            this.Text = memento.Text;
            Console.WriteLine($"Восстановление информации: {Text}");
        }
    }
    internal class GazetaWithDecor : GazetaDecorator
    { 
        public GazetaWithDecor(IGazeta gazeta) : base(gazeta) { }
        public override void Read()
        {
            Console.WriteLine("Газета с декоратором");
        }

    }
    // Pattern Memento
    class GazetaMemento
    {
        public string Text { get; set; }
        public GazetaMemento(string text)
        {
            this.Text = text;
        }
    }
    class EditionHistory
    {
        public Stack<GazetaMemento> history { get; private set; }
        public EditionHistory()
        {
            history = new Stack<GazetaMemento>();
        }
    }
    // Pattern Template Method
    abstract class Paper
    {
        public void TemplateMethod()
        {
            Origami();
            Launch();
        }
        protected abstract void Origami();
        protected abstract void Launch();
    }
    class PaperPlane : Paper, IStrategy
    {
        public PaperPlane() { }

        protected override void Launch()
        {
            Console.WriteLine("Запустили бумажный самолетик");
        }
        protected override void Origami()
        {
            Console.WriteLine("Собрали бумажный самолетик");
        }
        public void Broke()
        {
            Console.WriteLine("сломать бумажный самолетик");
        }
    }
    class PaperShip : Paper, IStrategy
    {
        public PaperShip() { }

        protected override void Launch()
        {
            Console.WriteLine("Пустили бумажный кораблик");
        }
        protected override void Origami()
        {
            Console.WriteLine("Собрали бумажный кораблик");
        }
        public void Broke()
        {
            Console.WriteLine("сломать бумажный кораблик");
        }
    }
    // Pattre Strategy
    public interface IStrategy
    {
        void Broke();
    }
    public class Context 
    {
        public IStrategy ContextStrategy { get; set; }
        public Context(IStrategy contextStrategy)
        {
            ContextStrategy = contextStrategy;
        }
        public void Execute()
        {
            ContextStrategy.Broke();
        }
    }

}

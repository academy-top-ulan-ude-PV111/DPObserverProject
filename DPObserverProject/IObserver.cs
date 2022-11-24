using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPObserverProject
{
    interface IObserver
    {
        void EventHandle(Object obj);
    }

    class Bank : IObserver
    {
        public string Title { set; get; }

        IObservable observable;

        public Bank(string title, IObservable observable)
        {
            Title = title;
            this.observable = observable;
            this.observable.AddObserver(this);
        }

        public void EventHandle(object obj)
        {
            StockInfo info = (obj as StockInfo);

            if(info.Usd < 60)
                Console.WriteLine($"Банк {Title} не продает доллар");
            else
                Console.WriteLine($"Банк {Title} продает доллар по {info.Usd + 0.5m}");

            if (info.Euro > 65)
                Console.WriteLine($"Банк {Title} продает евро по {info.Euro + 0.3m}");
            else
                Console.WriteLine($"Банк {Title} продает евро по {info.Euro + 0.5m}");
        }


        public void StopStock()
        {
            Console.WriteLine($"{Title} покидает биржу");
            observable.RemoveObserver(this);
            observable = null;
        }
    }

    class Broker : IObserver
    {
        public string Name { set; get; }

        IObservable observable;

        public Broker(string title, IObservable observable)
        {
            Name = title;
            this.observable = observable;
            this.observable.AddObserver(this);
        }

        public void EventHandle(object obj)
        {
            StockInfo info = (obj as StockInfo);

            if (info.Usd < 60)
                Console.WriteLine($"Брокер {Name} покупает по {info.Usd}");
            else
                Console.WriteLine($"Брокер {Name} не покупает по {info.Usd}");

            if (info.Euro > 65)
                Console.WriteLine($"Банк {Name} продает евро по {info.Euro + 0.3m}");
            else
                Console.WriteLine($"Банк {Name} продает евро по {info.Euro + 0.5m}");
        }

        public void StopStock()
        {
            Console.WriteLine($"{Name} покидает биржу");
            observable.RemoveObserver(this);
            observable = null;
        }
    }
}

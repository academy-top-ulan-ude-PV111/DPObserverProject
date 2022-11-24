using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPObserverProject
{
    interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    class StockInfo
    {
        public decimal Usd { set; get; }
        public decimal Euro { set; get; }
    }
    class Stock : IObservable
    {
        List<IObserver> observers;
        StockInfo info;

        public Stock()
        {
            observers = new();
            info = new();
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
                observer.EventHandle(info);
        }

        public void Auction()
        {
            Random rand = new();
            info.Usd = rand.Next(58, 65);
            info.Euro = rand.Next(60, 70);
            NotifyObservers();
        }
    }
}

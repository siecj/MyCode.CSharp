using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCode.CSharp.HeadFirstDesignPatterns.Chapter1
{
    abstract class Duck
    {
        protected IFlyBehavior FlyBehavior;
        protected IQuackBehavior QuackBehavior;

        public Duck() { }

        protected abstract void Display();

        internal virtual void PerformQuack()
        {
            QuackBehavior.Quack();
        }

        internal virtual void PerformFly()
        {
            FlyBehavior.Fly();
        }

        protected virtual void Swim()
        {
            Console.WriteLine("All ducks float, even decoys!");
        }

        internal void SetFlyBehavior(IFlyBehavior fb)
        {
            this.FlyBehavior = fb;
        }

        internal void SetQuackBehavior(IQuackBehavior qb)
        {
            this.QuackBehavior = qb;
        }
    }
}

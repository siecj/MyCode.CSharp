using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCode.CSharp.HeadFirstDesignPatterns.Chapter1
{
    class MallardDuck : Duck
    {
        public MallardDuck()
        {
            QuackBehavior = new Quack();
            FlyBehavior = new FlyWithWings();
        }

        protected override void Display()
        {
            Console.WriteLine("I'm a real Mallard Duck");
        }
    }
}

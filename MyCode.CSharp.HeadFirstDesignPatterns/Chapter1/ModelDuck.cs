using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCode.CSharp.HeadFirstDesignPatterns.Chapter1
{
    class ModelDuck : Duck
    {
        public ModelDuck()
        {
            this.FlyBehavior = new FlyNoWay();
            this.QuackBehavior = new Quack();
        }

        protected override void Display()
        {
            Console.WriteLine("I'm a model duck");
        }
    }
}

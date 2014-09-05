using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCode.CSharp.HeadFirstDesignPatterns.Chapter2
{
    public interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }
}

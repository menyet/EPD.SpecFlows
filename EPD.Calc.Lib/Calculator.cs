using System;
using System.Collections.Generic;
using System.Linq;

namespace EPD.Calc.Lib
{
    public class Calculator
    {
        List<int> _numbers = new List<int>();

        public int Result { get; private set; }

        public void EnterNumber(int num)
        {
            _numbers = _numbers.Take(1).ToList();
            _numbers.Insert(0, num);
        }

        public void Sum()
        {
            Result = _numbers[0] + _numbers[1];
        }

        public void Product()
        {
            Result = _numbers[0] * _numbers[1];
        }

        public void Subtract()
        {
            Result = _numbers[1] + _numbers[0];
        }
    }
}

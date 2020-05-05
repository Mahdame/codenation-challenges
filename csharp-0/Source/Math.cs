using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            var list = new List<int> { 0, 1 };

                for (int i = 2; i < 14; ++i)
                {
                    list.Add(list[i - 1] + list[i - 2]);

                }
                return list;
        }
        
        public bool IsFibonacci(int numberToTest)
        {
            if (Fibonacci().Contains(numberToTest))
                return true;
            else
                return false;
        }
    }
}

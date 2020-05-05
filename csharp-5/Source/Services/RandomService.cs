using System;

namespace Codenation.Challenge.Services
{
    public class RandomService: IRandomService
    {
        public int RandomInteger(int max)
        {
            var rand = new Random();
            return rand.Next(max);
        }
    }
}
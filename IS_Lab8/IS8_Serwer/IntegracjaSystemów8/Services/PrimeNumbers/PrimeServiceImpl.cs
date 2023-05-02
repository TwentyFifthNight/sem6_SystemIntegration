using System;

namespace IntegracjaSystemów8.Services.PrimeNumbers
{
    public class PrimeServiceImpl : IPrimeService
    {
        public int GetPrime()
        {
            int[] primes = { 2, 3, 5, 7, 11, 13 };

            var rand = new Random();

            return primes[rand.Next(primes.Length - 1)];
        }
    }
}

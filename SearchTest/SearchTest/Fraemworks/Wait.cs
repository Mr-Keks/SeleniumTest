using System;
using System.Threading;

namespace SearchTest.Fraemworks
{
    public class Wait
    {
        public static bool WaitFor(Func<bool> func, int milesecondsTimeout = 250, int waitInterval = 50)
        {
            DateTime start = DateTime.Now;
            do
            {
                if (func()) 
                    return true;
                Thread.Sleep(waitInterval);

            } while (DateTime.Now - start < TimeSpan.FromMilliseconds(milesecondsTimeout));

            return false;
        }
    }
}
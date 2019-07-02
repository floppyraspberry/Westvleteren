using System;
using System.Diagnostics;
using System.Threading;

namespace Westvleteren
{
    public class Waiter
    {
        public static void WaitForCondition(Func<bool> condition, int timeoutInSeconds = 60)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (stopWatch.Elapsed.Seconds < timeoutInSeconds)
            {
                try
                {
                    if (condition()) return;
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
            }

        }
    }
}

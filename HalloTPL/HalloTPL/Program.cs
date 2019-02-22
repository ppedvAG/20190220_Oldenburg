using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HalloTPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            throw new ExecutionEngineException();

            //Parallel.Invoke(Zähle, Zähle, Zähle);
            //Parallel.For(0, 100000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i:00}"));

            Task t1 = new Task(() =>
            {
                Console.WriteLine("Task 1 gestartet");
                Thread.Sleep(800);
                Console.WriteLine("Task 1 fertig");
            });

            var tc1 = t1.ContinueWith(t =>
            {
                Console.WriteLine("Task 1 continue");
            });


            Task t2 = new Task(() =>
            {
                Console.WriteLine("Task 2 gestartet");

                Thread.Sleep(1000);
                throw new ArgumentNullException();
                Console.WriteLine("Task 2 fertig");

            });

            t2.ContinueWith(t => Console.WriteLine("T2 OK"), TaskContinuationOptions.OnlyOnRanToCompletion);
            t2.ContinueWith(t =>
            {
                Console.WriteLine($"T2 Error: {t.Exception.InnerException.Message}");
            }, TaskContinuationOptions.OnlyOnFaulted);


            t1.Start();
            t2.Start();


            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private static void Zähle()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i:00}");
            }
        }
    }
}

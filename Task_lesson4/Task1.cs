using System;
using System.Threading;


namespace Task_lesson4.Task1
{
    // Задание 1. Реализовать шаблон «Одиночка» для многопоточной программы с использованием оператора lock.
    // Задание 2. Реализовать шаблон «Одиночка» для многопоточной программы с использованием класса Lazy<T>.

    class SingletonCounter
    {
        private static Lazy<SingletonCounter> _lazyInstance = new Lazy<SingletonCounter>(() => new SingletonCounter() );
        // Func<T>
        // не понимаю запись "() => new SingletonCounter() ", но это позволяет оставить конструктор private

        private static Object _loker = new Object();

        public static SingletonCounter Instance
        {
            get
            {

                SingletonCounter instance;

                lock (_loker)
                {
                    instance = _lazyInstance.Value;
                }

                return instance;
            }
        }

        public int Coutner { get; private set; }

        public void IncrementCounter()
        {
            lock (_loker)
            {
                Coutner++;
            }
        }

        private SingletonCounter()
        {
            Console.WriteLine("SingletonCounter::SingletonCounter:"); 
        }

    }

    public static class Task1
    {
        private const int TREADS_QUANTITY = 5;
        private const int REPEAT_QUANTITY = 200;
        private const int TREAD_TIME_OUT = 8;

        private static int localCounter;
        private static Object _loker = new Object();


        public static void ExecuteTask1()
        {
            Console.WriteLine("Task1::ExecuteTask1");
            localCounter = 0;

            Thread[] threads = new Thread[TREADS_QUANTITY];

            for (int i = 0; i < TREADS_QUANTITY; i++)
            {
                Thread t = new Thread(FunctionForParallrling);
                threads[i] = t;
                t.Start();
            }

            Console.WriteLine( $"TREADS_QUANTITY * REPEAT_QUANTITY = " +
                $"{TREADS_QUANTITY * REPEAT_QUANTITY }; " +
                $"SingletonCounter.Instance.Coutner = {SingletonCounter.Instance.Coutner}");

            WaitToTreadsFinished(threads);

            Console.WriteLine($"SingletonCounter.Instance.Coutner = {SingletonCounter.Instance.Coutner}");
            Console.WriteLine($"localCounter = {localCounter}");

        }

        private static void WaitToTreadsFinished(Thread[] threads)
        {
            Console.WriteLine("waiting...");
            int length = threads.Length;
            int count = 0;
            do
            {
                Thread.Sleep(TREAD_TIME_OUT);

                count = 0;

                for (int i = 0; i < length; i++)
                {
                    if (threads[i].ThreadState != ThreadState.Stopped)
                    {
                        count++;
                    }
                }

            } while (count != 0);
        }

        private static void FunctionForParallrling()
        {
            for (int i = 0; i < REPEAT_QUANTITY; i++)
            {
                Increment();
                SingletonCounter.Instance.IncrementCounter();

                Thread.Sleep(TREAD_TIME_OUT);
            }
            
        }

        private static void Increment()
        {
            lock (_loker)
            {
                localCounter++;  // этот счётчик после окончания работы всех потоков всегда правилный.
            }
        }
    }
}

using System;

namespace Messaging.Booking
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
                var rest = new Messaging.Booking.Restaraunt();
                while (true)
                {
                    await Task.Delay(10000);

                    Console.WriteLine("Привет! Желаете забронировать столик?");

                    var stopWatch = new Stopwatch();
                    stopWatch.Start();

                    rest BookFreeTabLeAsync(countOfPersons:1);
                    Console.WriteLine("Спасибо за Ваше обращение!");
                    stopWatch.Stop();
                    var ts:TimeSpan = stopWatch.Elapsed;
                    Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}");

                }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Restaurant.Messages;
using System.Linq;
using System.Text;

namespace Restaurant.Booking
{
    public class Worker : BackgroundService
    {
        private readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var a = new HashSet<Guid>();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (!stoppingToken.IsCancellationRequested)
            {

                Console.WriteLine("забронировать столик?");
                var b = Guid.NewGuid();

                var dateTime = DateTime.Now;
                await _bus.Publish(new BookingRequest(b, Guid.NewGuid(), null, dateTime),
                    stoppingToken);

                await Task.Delay(1000000, stoppingToken);
            }
        }
    }
}
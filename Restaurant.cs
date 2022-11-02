using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Booking
{
    public class Restaurant
    {
        private readonly List<Table> _tables = new();

        public Restaurant()
        {
                for (ushort i = 1; i <= 10; i++) _tables.Add(new Table(i));
        }

        public async Task<bool?> BookFreeTableAsync(int countOfPersons)
        {
            Console.WriteLine($"Спасибо за обращение," + "Мы Вам пришлем уведомление");

            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons
                                                        && t.State == TableState.Free);
            await Task.Delay(100 * 5);
            return table?.SetState(TableState.Booked);
        }
    }
}

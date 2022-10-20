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
            for (ushort i = 1; i <= 10; i++)
            {
                _tables.Add(new Table(i));
            }
        }

        public async Task<bool?> BookFreeTableAsync(int countOfPersons)
        {
            Console.WriteLine($"Спасибо обращение," + "Мы Вам пришлем уведомление");

            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons
                                                        && t.State == TableState.Free);
            return table?.SetState(TableState.Booked);
        }
    }
}

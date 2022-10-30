using System;

namespace Restaurant.Booking
{
    public class Table
    {
        public TableState State { get; private set; }
        public int SeatsCount { get; }
        public int Id { get; }

        public Table(int id)
        
        public bool SetState(TableState state)
        {
            lock (_lock)
            {
                if (state == State)
                    return false;

                State = state;
                return true;
            }
        }

        private readonly object _lock = new object();
        private static readonly Random Random = new();

    }
}
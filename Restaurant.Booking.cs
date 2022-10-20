using System;
using Automatonymous;

namespace Restaurant.Booking
{
    public class RestaurantBooking : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; } //для всех сообщений

        public int CurrentState { get; set; } //текущее состояние

        public Guid OrderId { get; set; } //заказа/бронирования

        public Guid ClientId { get; set; } //клиент

        public int ReadyEventStatus { get; set; } //события

        public Guid? ExpirationId { get; set; } //пометка о прокисшей заявке
    }
}

using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        private Reservation(
            ReservationId reservationId,
            int guestCount,
            ReservationStatus reservationStatus,
            GuestId guestId,
            BillId billId)
            : base(reservationId)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            ArrivalDateTime = DateTime.UtcNow;
            CreatedDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public int GuestCount { get; }
        public ReservationStatus ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public static Reservation Create(int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId)
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                reservationStatus,
                guestId,
                billId);
        }
    }
}

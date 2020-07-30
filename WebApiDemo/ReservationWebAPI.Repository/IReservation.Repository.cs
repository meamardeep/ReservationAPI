using ReservationWebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationWebAPIRepo
{
    public interface IReservation
    {
        //IEnumerable<Reservation> Reservations { get; }

        Reservation GetReservation(int reservationId);

        IEnumerable<Reservation> GetReservations();

        void CreateReservation(Reservation reservation);

        void UpdateReservation(Reservation reservation);

        void DeleteReservation(int ReservationId);

    }
}

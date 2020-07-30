using Microsoft.Extensions.Configuration;
using ReservationWebAPI;
using ReservationWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationWebAPIRepo
{
    public class ReservationRepository : IReservation
    {
        private ReservationDbContext _database;
        public ReservationRepository(IConfiguration configuration)
        {
            _database = new ReservationDbContext(configuration);
        }


        public IEnumerable<Reservation> GetReservations()
        {
            var sql = from r in _database.Reservations
                      where r.IsActive == true
                      select r;
            return sql;
        }

        public Reservation GetReservation(int reservationId)
        {
            var sql = from r in _database.Reservations
                      where r.ReservationId == reservationId
                      select r;
            return sql.FirstOrDefault();
        }

        public void CreateReservation(Reservation reservation)
        {
            _database.Add(reservation);

            _database.SaveChanges();
        }


        public void UpdateReservation(Reservation reservation)
        {
            Reservation reserv = GetReservation(reservation.ReservationId);

            reserv.Name = reservation.Name;
            reserv.StartLocation = reservation.StartLocation;
            reserv.EndLocation = reservation.EndLocation;
            
            _database.Update(reserv);

            _database.SaveChanges();
        }


        public void DeleteReservation(int reservationId)
        {
            Reservation reservation = GetReservation(reservationId);
            reservation.IsActive = false;

            _database.Update(reservation);
            _database.SaveChanges();
        }

        
    }
}

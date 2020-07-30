using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReservationWebAPI;
using ReservationWebAPI.Model;
using ReservationWebAPIRepo;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IReservation _reservationRepo;
        public ReservationController(IConfiguration configuration)
        {
            _reservationRepo = new ReservationRepository(configuration);
        }


        #region Reservation CRUD Web methods
        [HttpGet("GetReservations")]
        public ActionResult<IEnumerable<ReservationModel>> GetReservations()
        { 
            
            IEnumerable<Reservation> reservations = _reservationRepo.GetReservations();

            var models = from rs in reservations

                         select new ReservationModel
                         {
                             ReservationId = rs.ReservationId,
                             Name = rs.Name,
                             StartLocation = rs.StartLocation,
                             EndLocation = rs.EndLocation,
                             IsActive = rs.IsActive
                         };
            return models.ToList();
        }


        [HttpGet("GetReservation/{reservationId}")]
        public ActionResult<ReservationModel> GetReservation(int reservationId)
        {
            Reservation reservation = _reservationRepo.GetReservation(reservationId);

            ReservationModel model = new ReservationModel()
            {
                ReservationId = reservation.ReservationId,
                Name = reservation.Name,
                EndLocation = reservation.EndLocation,
                StartLocation = reservation.StartLocation,
                IsActive = reservation.IsActive
            };

            return model;          
        }

       
        [HttpPost("CreateReservation")]
        public void CreateReservation([FromBody] ReservationModel model)
        {
            Reservation reservation = new Reservation()
            {
                ReservationId = model.ReservationId,
                Name = model.Name,
                StartLocation = model.StartLocation,
                EndLocation = model.EndLocation,
                IsActive = true
            };

            if (reservation.ReservationId > 0)
            {
                _reservationRepo.UpdateReservation(reservation);
            }

            else
            {
                _reservationRepo.CreateReservation(reservation);
            }
        }

        // DELETE api/values/5
        [HttpDelete("DeleteReservation/{reservationId}")]
        public void DeleteReservation(int reservationId)
        {
            _reservationRepo.DeleteReservation(reservationId);
        }

        #endregion

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }
    }
}
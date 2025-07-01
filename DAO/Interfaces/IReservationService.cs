using System.Collections.Generic;
using CarConnectApp.Entity;

namespace CarConnectApp.DAO.Interfaces
{
    public interface IReservationService
    {
        void BookReservation(Reservation reservation);
        Reservation GetReservationById(int reservationId);
        List<Reservation> GetReservationsByCustomerId(int customerId);
        void CancelReservation(int reservationId);
    }
}

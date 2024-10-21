using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.DAO.Queries;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class BookingListDAO
    {
        public object getBookedApplication()
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString)) {

                dbConnection.Open();
                string query = BookingListQuery.GetBookedApplicationList;
                return dbConnection.Query(query).ToList();
            }
        }

        public object getBookingById(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = BookingListQuery.GetBookingById; // Implement your query here
                return dbConnection.Query(query, new { Id = id }).FirstOrDefault(); // Assuming you're using Dapper
            }
        }

        public void addBooking(BookingModelList booking)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = BookingListQuery.AddBooking; // Implement your query here
                dbConnection.Execute(query, booking); // Assuming you're using Dapper
            }
        }


        public int updateBooking(int roomId, int bookingId)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = BookingListQuery.UpdateBookingRoom; 
                 dbConnection.Execute(query, new { RoomId= roomId });

                string query1 = BookingListQuery.UpdateBooking; // implement your query here
                return dbConnection.Execute(query1, new { @BookingId = bookingId }); // assuming you're using dapper
            }
        }

        public int updateBookingCheckout(int roomId, int bookingId)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = BookingListQuery.UpdateCheckinRoom;
                 dbConnection.Execute(query, new { RoomId = roomId });

                string query1 = BookingListQuery.UpdateCheckinRooms; // implement your query here
                return dbConnection.Execute(query1, new { @BookingId = bookingId }); // assuming you're using dapper
            }
        }


        public void deleteBooking(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = BookingListQuery.DeleteBooking; // Implement your query here
                dbConnection.Execute(query, new { Id = id }); // Assuming you're using Dapper
            }
        }


        public object GetCheckInApplication()
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {

                dbConnection.Open();
                string query = CheckInListQuery.GetgetCheckInApplicationList;
                return dbConnection.Query(query).ToList();
            }
        }


        public BookingModelList GetCheckInById(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = CheckInListQuery.GetCheckInById; // Define this query in CheckInListQuery
                return dbConnection.QuerySingleOrDefault<BookingModelList>(query, new { Id = id });
            }
        }


        public ResultModel AddCheckIn(BookingModelList booking)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = CheckInListQuery.AddCheckIn; // Define this query in CheckInListQuery
                var result = dbConnection.Execute(query, booking);

                return new ResultModel
                {
                    Success = result > 0, // If rows affected > 0, it was successful
                    Data = booking,
                    TechDetails = result > 0 ? string.Empty : "Failed to add check-in"
                };
            }
        }


        public ResultModel UpdateCheckIn(BookingModelList booking)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = CheckInListQuery.UpdateCheckIn; // Define this query in CheckInListQuery
                var result = dbConnection.Execute(query, booking);

                return new ResultModel
                {
                    Success = result > 0, // If rows affected > 0, it was successful
                    Data = booking,
                    TechDetails = result > 0 ? string.Empty : "Failed to update check-in"
                };
            }
        }




        public ResultModel DeleteCheckIn(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = CheckInListQuery.DeleteCheckIn; // Define this query in CheckInListQuery
                var result = dbConnection.Execute(query, new { Id = id });

                return new ResultModel
                {
                    Success = result > 0, // If rows affected > 0, it was successful
                    Data = null,
                    TechDetails = result > 0 ? string.Empty : "Failed to delete check-in"
                };
            }
        }

        public object GetCheckOutApplication()
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {

                dbConnection.Open();
                string query = CheckOutListQuery.GetgetCheckOutApplicationList;
                return dbConnection.Query(query).ToList();
            }
        }

        public object GetCheckOutById(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = CheckOutListQuery.GetCheckOutByIdQuery; // Make sure to define this query
                var parameters = new { Id = id };
                return dbConnection.QuerySingleOrDefault(query, parameters);
            }
        }


        public bool AddCheckOut(BookingModelList checkOut)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = CheckOutListQuery.AddCheckOutQuery; // Make sure to define this query
                var result = dbConnection.Execute(query, checkOut);
                return result > 0; // Returns true if one or more rows were affected
            }
        }



        public bool UpdateCheckOut(int id, BookingModelList checkOut)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = CheckOutListQuery.UpdateCheckOutQuery; // Make sure to define this query
                checkOut.Booking_ID = id; // Assuming your CheckOutModel has a BookingId property
                var result = dbConnection.Execute(query, checkOut);
                return result > 0; // Returns true if one or more rows were affected
            }
        }


        public bool DeleteCheckOut(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DapperDb"].ConnectionString))
            {
                dbConnection.Open();
                string query = CheckOutListQuery.DeleteCheckOutQuery; // Make sure to define this query
                var parameters = new { Id = id };
                var result = dbConnection.Execute(query, parameters);
                return result > 0; // Returns true if one or more rows were affected
            }
        }

    }

}
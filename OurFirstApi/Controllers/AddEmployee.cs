using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using OurFirstApi.Models;

namespace OurFirstApi.Controllers
{
    //api/employees
    public class AddEmployee : ApiController
    {
        //api/employees
        public HttpResponseMessage Post()
        {
            Console.WriteLine("Enter first name:");
            var x = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            var y = Console.ReadLine();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    var rowsAffected = connection.Execute("Insert into Employee(FirstName, LastName) " +
                                                          "Values(@FirstName, @LastName)",
                        new { FirstName = x, LastName = y });

                    Console.WriteLine(rowsAffected != 1 ? "Add Failed" : "Success!");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("You done messed up");
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                return 

                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadLine();
            }
        }

        //api/employees/3000
        public HttpResponseMessage Get(int id)
        {
            using (var connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    var result =
                        connection.Query<EmployeeListResult>("Select * From Employee where EmployeeId = @id",
                            new { id = id }).FirstOrDefault();

                    if (result == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with the Id {id} was not found");
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
        }
    }
}

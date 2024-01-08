using CRUDwithDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CRUDwithDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GetAllCustomers
        [HttpGet]
        [Route("GetAllCustomers")]
        public Response GetAllCustomers() 
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllCustomers(connection);

            return response;
        }

        // AddCustomer
        [HttpPost]
        [Route("AddCustomer")]
        public Response AddEmployee(Customer customer) 
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddCustomer(connection, customer);

            return response;
        }

        // UpdateCustomer
        [HttpPut]
        [Route("UpdateCustomer")]
        public Response UpdateCustomer(Customer customer)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateCustomer(connection, customer);

            return response;
        }

        // DeleteCustomer
        [HttpDelete]
        [Route("DeleteCustomer/{UserId}")]
        public Response DeleteCustomer(string UserId)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteCustomer(connection, UserId);

            return response;
        }
    }
}

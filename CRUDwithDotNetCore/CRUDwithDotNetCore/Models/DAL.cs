using System.Data;
using System.Data.SqlClient;

namespace CRUDwithDotNetCore.Models
{
    public class DAL
    {
        public Response GetAllCustomers(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from Customer", connection);
            DataTable dt = new DataTable();
            List<Customer> customers = new List<Customer>();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++) 
                {
                    Customer customer = new Customer();
                    customer.UserId = Guid.Parse(Convert.ToString(dt.Rows[i]["UserId"]));
                    customer.Username = Convert.ToString(dt.Rows[i]["Username"]);
                    customer.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    customer.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    customer.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    customer.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    customer.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                    customers.Add(customer);
                }
            }

            if (customers.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.customers = customers;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data Found";
                response.customers = null;
            }

            return response;
        }

        public Response AddCustomer(SqlConnection connection, Customer customer)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customer(UserId,Username,Email,FirstName,LastName,CreatedOn,IsActive) VALUES('" + Guid.NewGuid() + "', '"+ customer.Username + "', '"+ customer.Email + "', '" + customer.FirstName + "' , '" + customer.LastName +"', GETDATE(),'"+customer.IsActive+"')", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Customer Added";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data Inserted";
            }

            return response;
        }

        public Response UpdateCustomer(SqlConnection connection, Customer customer)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Customer SET Username = '" + customer.Username + "', Email='" + customer.Email + "', FirstName='" + customer.FirstName + "', LastName='" + customer.LastName + "', IsActive='" + customer.IsActive + "' WHERE UserId = '" + customer.UserId.ToString() + "' ", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Customer Updated";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data Updated";
            }

            return response;
        }

        public Response DeleteCustomer(SqlConnection connection, string UserId)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE UserId = '" + UserId + "' ", connection);

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Customer Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Customer Deletion Failed";
            }

            return response;
        }
    }

    
}

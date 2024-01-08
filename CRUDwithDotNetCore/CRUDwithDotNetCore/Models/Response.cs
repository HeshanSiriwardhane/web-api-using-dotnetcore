namespace CRUDwithDotNetCore.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Customer> customers { get; set; }
    }
}

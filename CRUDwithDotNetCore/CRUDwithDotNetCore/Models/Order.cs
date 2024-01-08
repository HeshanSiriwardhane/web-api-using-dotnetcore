namespace CRUDwithDotNetCore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public int OrderBy { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime ShippedOn { get; set; }
        public bool IsActive { get; set; }
    }
}

namespace Shashwat.Models
{
    public class Order
    {
       
            public int OrderId { get; set; }
        public string CartID { get; set; }
            public int PieId { get; set; }
        public int Quantity { get; set; }

            public string PieName { get; set; }

            public decimal PiePrice { get; set; }
        
    }
}

using System;

namespace BookStore.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public DateTime DateTime { get; set; }
        
        public Book BookId { get; set; }
        public Book Book { get; set; }
    }
}
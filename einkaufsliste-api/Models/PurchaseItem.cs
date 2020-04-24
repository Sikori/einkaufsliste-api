using System;
namespace einkaufsliste_api.Models
{
    public class PurchaseItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPurchased { get; set; }
    }
}

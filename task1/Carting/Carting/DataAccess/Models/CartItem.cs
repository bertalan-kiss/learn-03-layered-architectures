﻿namespace Carting.DataAccess.Models
{
    public class CartItem
    {
        public int CartId { get; set; }
        public int _id { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}


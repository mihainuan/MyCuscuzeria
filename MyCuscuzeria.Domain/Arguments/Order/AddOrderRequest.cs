using MyCuscuzeria.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Arguments.Order
{
    public class AddOrderRequest
    {
        public int OrderId { get; set; }
        //public int CuscuzeiroId { get; set; }
        //public int UserId { get; set; }

        //public int BeverageId { get; set; }
        //public int CuscuzId { get; set; }
        //public int DrinkId { get; set; }
        //public int PromoId { get; set; }

        public StatusEnum OrderStatus { get; set; }
        public DateTime OrderCreation { get; set; }
        public bool Delivered { get; set; }

        public decimal OrderTotal { get; set; }

        //FK (one-to-one)
        public virtual Entities.Cuscuzeiro Cuscuzeiro { get; set; }
        public virtual Entities.User User { get; set; }

        //FK (one-to-many)
        public virtual ICollection<Entities.Beverage> Beverages { get; set; }
        public virtual ICollection<Entities.Cuscuz> Cuscuzes { get; set; }
        public virtual ICollection<Entities.Drink> Drinks { get; set; }
        public virtual ICollection<Entities.Promo> Promo { get; set; }

        void Order()
        {
            Beverages = new List<Entities.Beverage>();
            Cuscuzes = new List<Entities.Cuscuz>();
            Drinks = new List<Entities.Drink>();
            Promo = new List<Entities.Promo>();
        }
    }
}
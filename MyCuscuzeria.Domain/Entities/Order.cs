using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Entities
{
    public class Order : EntityBase
    {
        //PK
        public int OrderId { get; set; }

        public int CuscuzeiroId { get; set; }
        public int UserId { get; set; }

        public int BeverageId { get; set; }
        public int CuscuzId { get; set; }
        public int DrinkId { get; set; }
        public int PromoId { get; set; }

        public StatusEnum OrderStatus { get; set; }
        public DateTime OrderCreation { get; set; }
        public bool Delivered { get; set; }

        public decimal OrderTotal { get; set; }

        //FK (one-to-one)
        public virtual Cuscuzeiro Cuscuzeiro { get; set; }
        public virtual User User { get; set; }

        //FK (one-to-many)
        public virtual ICollection<Beverage> Beverages { get; set; }
        public virtual ICollection<Cuscuz> Cuscuzes { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; }
        public virtual ICollection<Promo> Promo { get; set; }

        public Order()
        {
            Beverages = new List<Beverage>();
            Cuscuzes = new List<Cuscuz>();
            Drinks = new List<Drink>();
            Promo = new List<Promo>();
        }



        public Order(StatusEnum OrderStatus, DateTime OrderCreation, decimal OrderTotal, Cuscuzeiro Cuscuzeiro, User User)
        {
            OrderStatus = OrderStatus;
            OrderCreation = OrderCreation;
            OrderTotal = OrderTotal;
            Cuscuzeiro = Cuscuzeiro;
            User = User;

            Beverages = new List<Beverage>();
            Cuscuzes = new List<Cuscuz>();
            Drinks = new List<Drink>();
            Promo = new List<Promo>();

            //new AddNotifications<Order>(this).IfNullOrInvalidLength(x => x.PromoTitle, 2, 100,
            //        MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES)
            //    .IfNullOrInvalidLength(x => x.Description, 10, 200,
            //        MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES);
            //AddNotifications(order);
        }
    }
}

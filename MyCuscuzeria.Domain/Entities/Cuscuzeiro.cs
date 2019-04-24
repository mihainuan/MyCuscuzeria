using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using System;

namespace MyCuscuzeria.Domain.Entities
{
    public class Cuscuzeiro : EntityBase
    {
        //PK
        public int CuscuzeiroId { get; private set; }

        public string CuscuzeiroName { get; private set; }
        public int Age { get; set; }
        public DateTime? StartDate { get; private set; }
        public string UrlImg { get; private set; }

        public int OrderId { get; private set; }
        public virtual Order Order { get; private set; }

        public Cuscuzeiro(string cuscuzeironame, Order order)
        {
            CuscuzeiroName = cuscuzeironame;
            Order = order;

            new AddNotifications<Cuscuzeiro>(this).IfNullOrInvalidLength(x => x.CuscuzeiroName, 2, 100,
                    MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES);

            AddNotifications(order);
        }

        protected Cuscuzeiro()
        {

        }
    }
}

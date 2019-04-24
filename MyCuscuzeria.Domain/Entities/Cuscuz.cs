using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Entities
{
    public class Cuscuz : EntityBase
    {
        //PK
        public int CuscuzId { get; private set; }

        public string CuscuzName { get; private set; }
        public string Description { get; private set; }

        public int OrderId { get; private set; }
        public int TypeId { get; private set; }
        public int AccompanimentId { get; private set; }

        //FK (one-to-one)
        public virtual Order Order { get; private set; }
        public virtual Type Type { get; private set; }

        //FK (one-to-many)
        public virtual ICollection<Accompaniment> Accompaniments { get; private set; }

        public Cuscuz(string cuscuzname, string description, Order order)
        {
            CuscuzName = cuscuzname;
            Description = description;
            Order = order;

            Accompaniments = new List<Accompaniment>();

            new AddNotifications<Cuscuz>(this).IfNullOrInvalidLength(x => x.CuscuzName, 2, 100,
                    MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES)
                .IfNullOrInvalidLength(x => x.Description, 10, 200,
                    MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES);

            AddNotifications(order);
        }

        protected Cuscuz()
        {

        }
    }
}

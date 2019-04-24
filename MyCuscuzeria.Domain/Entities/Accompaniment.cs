using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace MyCuscuzeria.Domain.Entities
{
    public class Accompaniment : EntityBase
    {
        //PK
        public int AccompanimentId { get; private set; }

        public string AccompanimentName { get; private set; }
        public string Description { get; private set; }

        public int CuscuzId { get; private set; }
        public virtual Cuscuz Cuscuz { get; private set; }


        public Accompaniment(string accompanimentname, string description, Cuscuz cuscuz)
        {
            AccompanimentName = accompanimentname;
            Description = description;
            Cuscuz = cuscuz;

            new AddNotifications<Accompaniment>(this)
                .IfNullOrInvalidLength(x => x.AccompanimentName, 2, 100,
                    MSG.X0_E_OBRIGATORIO_E_DEVE_CONTER_X1_CARACTERES.ToFormat("2", "100"))
                .IfNullOrInvalidLength(x => x.Description, 10, 100,
                    MSG.X0_E_OBRIGATORIO_E_DEVE_CONTER_X1_CARACTERES.ToFormat("10", "100"));

            AddNotifications(cuscuz);
        }

        protected Accompaniment()
        {

        }


    }
}

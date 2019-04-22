using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace MyCuscuzeria.Domain.Entities
{
    public class Accompaniment : EntityBase
    {
        //PK
        public int AccompanimentId { get; set; }

        public string AccompanimentName { get; set; }
        public string Description { get; set; }

        public int CuscuzId { get; set; }
        public virtual Cuscuz Cuscuz { get; set; }


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


    }
}

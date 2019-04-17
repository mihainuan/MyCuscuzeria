using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace MyCuscuzeria.Domain.Entities
{
    public class Type : EntityBase
    {
        //PK
        public int TypeId { get; set; }
        public string TypeName { get; private set; }
        public string Description { get; private set; }
        public virtual Cuscuz Cuscuz { get; private set; }


        public Type(string typeName, string description, Cuscuz cuscuz)
        {
            TypeName = typeName;
            Description = description;
            Cuscuz = cuscuz;

            new AddNotifications<Type>(this)
                .IfNullOrInvalidLength(x => x.TypeName, 2, 100,
                    MSG.X0_E_OBRIGATORIO_E_DEVE_CONTER_X1_CARACTERES.ToFormat("2", "100"))
                .IfNullOrInvalidLength(x => x.Description, 10, 100,
                    MSG.X0_E_OBRIGATORIO_E_DEVE_CONTER_X1_CARACTERES.ToFormat("10", "100"));

            AddNotifications(cuscuz);
        }
    }
}

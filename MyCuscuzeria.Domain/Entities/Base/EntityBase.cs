using prmToolkit.NotificationPattern;
using System;

namespace MyCuscuzeria.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        public EntityBase()
        {
            //Alternative PK
            GuId = Guid.NewGuid();
        }
        public virtual Guid GuId { get; set; }
    }
}
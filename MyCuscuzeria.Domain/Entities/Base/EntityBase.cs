using System;

namespace MyCuscuzeria.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            //Alternative PK
            GuId = Guid.NewGuid();
        }
        public virtual Guid GuId { get; set; }
    }
}
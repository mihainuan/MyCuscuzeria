using MyCuscuzeria.Domain.Entities.Base;

namespace MyCuscuzeria.Domain.Entities
{
    public class Type : EntityBase


    {   //PK
        public int TypeId { get; set; }

        public string TypeName { get; set; }
        public string Description { get; set; }

        public virtual Cuscuz Cuscuz { get; set; }
    }
}

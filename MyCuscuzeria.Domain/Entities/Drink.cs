using MyCuscuzeria.Domain.Entities.Base;

namespace MyCuscuzeria.Domain.Entities
{
    public class Drink : EntityBase
    {
        //PK
        public int DrinkId { get; set; }

        public string DrinkName { get; set; }
        public string Description { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}

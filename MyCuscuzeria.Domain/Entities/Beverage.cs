﻿using MyCuscuzeria.Domain.Entities.Base;

namespace MyCuscuzeria.Domain.Entities
{
    public class Beverage : EntityBase
    {
        //PK
        public int BeverageId { get; set; }

        public string BeverageName { get; set; }
        public string Description { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}

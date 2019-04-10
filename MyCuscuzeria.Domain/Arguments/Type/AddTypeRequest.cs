namespace MyCuscuzeria.Domain.Arguments.Type
{
    public class AddTypeRequest
    {
        public int TypeId { get; set; }

        public string TypeName { get; set; }
        public string Description { get; set; }

        public virtual Entities.Cuscuz Cuscuz { get; set; }
    }
}
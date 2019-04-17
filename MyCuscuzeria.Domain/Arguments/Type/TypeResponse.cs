namespace MyCuscuzeria.Domain.Arguments.Type
{
    public class TypeResponse
    {
        public int TypeId { get; set; }

        public string TypeName { get; set; }
        public string Description { get; set; }

        public virtual Entities.Cuscuz Cuscuz { get; set; }

        public static explicit operator TypeResponse(Entities.Type entity)
        {
            return new TypeResponse()
            {
                TypeId = entity.TypeId,
                TypeName = entity.TypeName,
                Description = entity.Description,
                Cuscuz = entity.Cuscuz
            };
        }
    }
}
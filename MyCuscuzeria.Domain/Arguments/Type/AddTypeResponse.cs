namespace MyCuscuzeria.Domain.Arguments.Type
{
    public class AddTypeResponse
    {
        public int TypeId { get; set; }

        public AddTypeResponse(int typeid)
        {
            typeid = TypeId;
        }
    }
}
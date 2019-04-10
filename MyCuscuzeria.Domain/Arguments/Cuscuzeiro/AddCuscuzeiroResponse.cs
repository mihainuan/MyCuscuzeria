namespace MyCuscuzeria.Domain.Arguments.Cuscuzeiro
{
    public class AddCuscuzeiroResponse
    {
        public int CuscuzeiroId { get; set; }

        public AddCuscuzeiroResponse(int cuscuzeiroid)
        {
            cuscuzeiroid = CuscuzeiroId;
        }
    }
}
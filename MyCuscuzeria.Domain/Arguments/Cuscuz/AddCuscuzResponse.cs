namespace MyCuscuzeria.Domain.Arguments.Cuscuz
{
    public class AddCuscuzResponse
    {
        public int CuscuzId { get; set; }

        public AddCuscuzResponse(int cuscuzid)
        {
            cuscuzid = CuscuzId;
        }
    }
}
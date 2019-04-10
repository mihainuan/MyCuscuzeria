namespace MyCuscuzeria.Domain.ValueObjects
{
    public class FullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public FullName(string firstName, string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
}
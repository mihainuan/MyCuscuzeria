using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace MyCuscuzeria.Domain.ValueObjects
{
    public class FullName : Notifiable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new AddNotifications<FullName>(this)
                .IfNullOrInvalidLength(x => x.FirstName, 1, 50, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("First Name", 3, 50))
                .IfNullOrInvalidLength(x => x.LastName, 1, 50, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Last Name", 3, 50));
        }

        protected FullName()
        {

        }
    }
}
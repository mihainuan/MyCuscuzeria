using prmToolkit.NotificationPattern;
using System;

namespace MyCuscuzeria.Domain.Services.Base
{
    public interface IServiceBase : INotifiable, IDisposable
    {
    }
}
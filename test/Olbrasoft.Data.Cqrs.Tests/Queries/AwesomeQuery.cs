using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Data.Cqrs.Queries
{
    public class AwesomeQuery : Request<bool>
    {
        public AwesomeQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}
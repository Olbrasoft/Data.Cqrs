using Olbrasoft.Dispatching.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Cqrs
{
    public class AwesomeBooleanQueryHandler : QueryHandler<Request<bool>>
    {
        public override Task<bool> HandleAsync(Request<bool> query, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}
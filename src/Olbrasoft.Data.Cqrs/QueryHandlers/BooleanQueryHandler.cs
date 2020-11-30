using Olbrasoft.Dispatching.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Cqrs.QueryHandlers
{
    public abstract class BooleanQueryHandler<TQuery> : IRequestHandler<TQuery, bool> where TQuery : IRequest<bool>
    {
        public abstract Task<bool> HandleAsync(TQuery query, CancellationToken token);
    }
}
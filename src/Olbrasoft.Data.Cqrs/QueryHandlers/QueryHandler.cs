using Olbrasoft.Dispatching.Common;
using Olbrasoft.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Cqrs.QueryHandlers
{
    public abstract class QueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IRequest<TResult>
    {
        private readonly IProjector _projector;

        public QueryHandler(IProjector projector) => _projector = projector;

        public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken token);

        protected IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source) => _projector.ProjectTo<TDestination>(source);
    }
}
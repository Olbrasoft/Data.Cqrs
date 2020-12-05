using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Data.Cqrs.Queries
{
    public class DataTablesPagedQuery<TResult> : PagedQuery<TResult>
    {
        public DataTablesPagedQuery(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public DataTablesPagedQuery(IRequestHandler<Request<TResult>, TResult> handler) : base(handler)
        {
        }

        public OrderDirection OrderByDirection { get; set; }

        public string OrderByColumnName { get; set; }

        public string Search { get; set; }
    }
}
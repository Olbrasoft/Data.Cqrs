using Olbrasoft.Dispatching.Common;
using Olbrasoft.Mapping;

namespace Olbrasoft.Data.Cqrs.EntityFrameworkCore
{
    public abstract class DbCommandHandler<TCommand, TResult, TContext, TEntity> : CommandHandler<TCommand, TResult> where TCommand : Request<TResult>
    {
        protected DbCommandHandler(IMapper mapper) : base(mapper)
        {
        }
    }
}
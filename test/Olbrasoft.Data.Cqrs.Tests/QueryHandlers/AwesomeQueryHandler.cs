using Olbrasoft.Data.Cqrs.Queries;
using Olbrasoft.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Cqrs.QueryHandlers
{
    internal class AwesomeQueryHandler : QueryHandler<AwesomeQuery, bool>
    {
        public AwesomeQueryHandler(IProjector projector) : base(projector)
        {
        }

        public void CallProjectTo()
        {
            ProjectTo<string>(new List<char>().AsQueryable());
        }

        public override Task<bool> HandleAsync(AwesomeQuery query, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}
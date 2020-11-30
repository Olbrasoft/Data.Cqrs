using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Data.Cqrs.Commands
{
    public class SaveCommand : Request<bool>
    {
        public int Id { get; set; }

        public SaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        public SaveCommand(IRequestHandler<Request<bool>, bool> handler) : base(handler)
        {
        }
    }
}
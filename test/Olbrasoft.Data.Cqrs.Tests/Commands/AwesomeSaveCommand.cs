using Olbrasoft.Dispatching.Common;

namespace Olbrasoft.Data.Cqrs.Commands
{
    internal class AwesomeSaveCommand : SaveCommand
    {
        public AwesomeSaveCommand(IDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}
using Moq;
using Olbrasoft.Dispatching.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Cqrs
{
    public class BaseTest
    {
        public Mock<IDispatcher> DispatcherMock => new Mock<IDispatcher>();

        public Mock<IRequestHandler<IRequest<object>, object>> HandlerMock => new Mock<IRequestHandler<IRequest<object>, object>>();

        public Mock<IRequestHandler<IRequest<bool>, bool>> BoleanHandlerMock => new Mock<IRequestHandler<IRequest<bool>, bool>>();
    }
}
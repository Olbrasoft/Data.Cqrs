using Moq;
using Olbrasoft.Data.Cqrs.Queries;
using Olbrasoft.Mapping;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Olbrasoft.Data.Cqrs.QueryHandlers
{
    public class QueryHandlerTest
    {
        [Fact]
        public void QueryHandler_Is_Abstract()
        {
            //Arrange
            var type = typeof(QueryHandler<,>);

            //Act
            var result = type.IsAbstract;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AwesomeQueryHandler_Inherit_From_QueryHandler_Of_AwesomeQuery_Comma_Object()
        {
            //Arrange
            var type = typeof(QueryHandler<AwesomeQuery, bool>);
            var projectorMock = CreateProjectorMock();

            //Act
            var handler = new AwesomeQueryHandler(projectorMock.Object);

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static Mock<IProjector> CreateProjectorMock()
        {
            return new Mock<IProjector>();
        }

        [Fact]
        public void ProjectTo_Call_Method_ProjectTo_On_Projector()
        {
            //Arrange
            var projectorMock = CreateProjectorMock();
            var handler = new AwesomeQueryHandler(projectorMock.Object);
            var queryable = new List<char>().AsQueryable();

            //Act
            handler.CallProjectTo();

            //Assert
            projectorMock.Verify(p => p.ProjectTo<string>(queryable));
        }
    }
}
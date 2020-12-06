using Microsoft.EntityFrameworkCore;
using Moq;
using Olbrasoft.Dispatching.Common;
using Olbrasoft.Mapping;
using System.Linq;
using Xunit;

namespace Olbrasoft.Data.Cqrs.EntityFrameworkCore
{
    public class DbQueryHandlerTest
    {
        [Fact]
        public void DbQueryHandler_Is_Abstract()
        {
            //Arrange
            var type = typeof(DbQueryHandler<,,,>);

            //Act
            var result = type.IsAbstract;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AwesomeQueryHandler_Inherit_From_DbQueryHandler_Of_AwesomeEntity_Comma_Request_Of_Object_Comma_Object()
        {
            //Arrange
            var type = typeof(DbQueryHandler<Request<object>, object, DbContext, AwesomeEntity>);

            //Act
            var handler = CreateAwesomeQueryHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static AwesomeQueryHandler CreateAwesomeQueryHandler()
        {
            var projectorMock = new Mock<IProjector>();
            var factoryMock = new Mock<IDbContextFactory<DbContext>>();
            var contextMock = new Mock<DbContext>();
            var setMock = new Mock<DbSet<AwesomeEntity>>();

            contextMock.Setup(p => p.Set<AwesomeEntity>()).Returns(setMock.Object);

            factoryMock.Setup(p => p.CreateDbContext()).Returns(contextMock.Object);

            return new AwesomeQueryHandler(projectorMock.Object, factoryMock.Object);
        }

        [Fact]
        public void AwesomeDbQueryHandler_Of_AwesomeEntity_Comma_Request_Of_Object_Comma_Object_Inherit_From_QueryHandler_Of_Request_Of_Object_comma_Object()
        {
            //Arrange
            var type = typeof(QueryHandler<Request<object>, object>);

            //Act
            var handler = CreateAwesomeQueryHandler();

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        [Fact]
        public void AwesomeQueryHandler_Property_Context_Return_Base_Protected_Property_Context_Type_Of_DbContext()
        {
            //Arrange
            var handler = CreateAwesomeQueryHandler();

            //Act
            var result = handler.Context;

            //Assert
            Assert.IsAssignableFrom<DbContext>(result);
        }

        [Fact]
        public void AwesomeQueryHandler_Property_Entities_Return_Base_Protected_Property_Type_Of_IQueryable_Of_AwesomeEntity()
        {
            //Arrange
            var handler = CreateAwesomeQueryHandler();

            //Act
            var result = handler.Entities;

            //Assert
            Assert.IsAssignableFrom<IQueryable<AwesomeEntity>>(result);
        }
    }
}
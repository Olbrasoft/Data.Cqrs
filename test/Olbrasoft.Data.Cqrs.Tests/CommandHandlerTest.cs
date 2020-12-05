using Moq;
using Olbrasoft.Dispatching.Common;
using Olbrasoft.Mapping;
using Xunit;

namespace Olbrasoft.Data.Cqrs
{
    public class CommandHandlerTest : BaseTest
    {
        [Fact]
        public void AwesomeCommandHandler_Inherit_From_CommandHandler()
        {
            //Arrange
            var type = typeof(CommandHandler<Request<bool>, bool>);

            //Act
            var handler = new AwesomeCommandHandler<Request<bool>, bool>(CreateMapperMock().Object);

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }

        private static Mock<IMapper> CreateMapperMock()
        {
            return new Mock<IMapper>();
        }

        [Fact]
        public void AwesomeCommandHandler_MapTo_Calls_The_MapTo_Method_On_The_Mapper()
        {
            //Arrange
            var mapperMock = CreateMapperMock();
            var handler = new AwesomeCommandHandler<Request<bool>, bool>(mapperMock.Object);

            //Act
            handler.Call_MapTo_Of_String_With_Parameter_Of_Type_String();

            //Assert
            mapperMock.Verify(P => P.MapTo<string>(""));
        }

        [Fact]
        public void AwesomeHandler_Inherit_From_CommandHandler_Of_Request_Of_Bool()
        {
            //Arrange
            var type = typeof(CommandHandler<Request<bool>>);

            //Act
            var handler = new AwesomeCommandHandler(CreateMapperMock().Object);

            //Assert
            Assert.IsAssignableFrom(type, handler);
        }
    }
}
using Moq;
using Olbrasoft.Dispatching.Common;
using Xunit;

namespace Olbrasoft.Data.Cqrs.Commands
{
    public class SaveCommandTest
    {
        [Fact]
        public void AwesomeSaveCommand_Inherit_From_SaveCommand()
        {
            //Arrange
            var type = typeof(SaveCommand);

            //Act
            var command = CreateAwesomeCommand();

            //Assert
            Assert.IsAssignableFrom(type, command);
        }

        private static AwesomeSaveCommand CreateAwesomeCommand()
        {
            var dispatcherMock = new Mock<IDispatcher>();

            return new AwesomeSaveCommand(dispatcherMock.Object);
        }

        [Fact]
        public void AwesomeSaveCommand_Inherit_From_Request_Of_Bool()
        {
            var type = typeof(Request<bool>);

            var command = CreateAwesomeSaveCommand();

            Assert.IsAssignableFrom(type, command);
        }

        private static AwesomeSaveCommand CreateAwesomeSaveCommand()
        {
            var dispatcherMock = new Mock<IDispatcher>();

            var command = new AwesomeSaveCommand(dispatcherMock.Object);
            return command;
        }

        [Fact]
        public void Property_Id_Is_Integer()
        {
            //Arrange
            var type = typeof(int);
            var command = CreateAwesomeSaveCommand();

            //Act
            var id = command.Id;

            //Assert
            Assert.IsAssignableFrom(type, id);
        }
    }
}
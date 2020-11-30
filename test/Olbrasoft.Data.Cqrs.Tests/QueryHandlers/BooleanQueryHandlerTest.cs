using Olbrasoft.Data.Cqrs.Queries;
using Xunit;

namespace Olbrasoft.Data.Cqrs.QueryHandlers
{
    public class BooleanQueryHandlerTest
    {
        [Fact]
        public void BooleanQueryHandler_Is_Abstract()
        {
            //Arrange
            var type = typeof(BooleanQueryHandler<AwesomeQuery>);

            //Act
            var result = type.IsAbstract;

            //Assert
            Assert.True(result);
        }
    }
}
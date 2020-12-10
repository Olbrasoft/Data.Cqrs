using Moq;
using System;
using System.Linq;
using Xunit;

namespace Olbrasoft.Data.Cqrs.EntityFrameworkCore
{
    public class DbCommandHandlerTest
    {
        [Fact]
        public void DbCommandHandler_Is_Class()
        {
            //Arrange
            var type = TypeOfCommandHandler();

            //Act
            var result = type.IsClass;

            //Assert
            Assert.True(result);
        }

        private static Type TypeOfCommandHandler()
        {
            return typeof(DbCommandHandler<,,,>);
        }

        [Fact]
        public void DbCommandHandler_Is_Abstract()
        {
            //Arrange
            var type = TypeOfCommandHandler();

            //Act
            var result = type.IsAbstract;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DbCommandHandler_Is_Generic()
        {
            //Arrange
            var type = TypeOfCommandHandler();

            //Act
            var result = type.IsGenericType;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void The_DbCommandHandler_Has_Four_Generic_Attributes()
        {
            //Arrange
            var type = TypeOfCommandHandler();

            //Act
            var numberOfGenericArguments = type.GetGenericArguments().Count();

            //Assert
            Assert.True(numberOfGenericArguments == 4);
        }

        [Fact]
        public void The_Name_Of_The_First_Generic_Argument_Is_TCommand()
        {
            //Arrange
            var name = "TCommand";

            //Act
            var argumentName = GetNameOfGenericArgument();
            //Assert
            Assert.True(name == argumentName);
        }

        [Fact]
        public void The_Name_Of_The_Second_Generic_Argument_Is_TResult()
        {
            //Arrange
            var name = "TResult";

            //Act
            var argumentName = GetNameOfGenericArgument(1);

            //Assert
            Assert.True(name == argumentName);
        }

        [Fact]
        public void The_Name_Of_The_Third_Generic_Argument_Is_TContext()
        {
            //Arrange
            var name = "TContext";

            //Act
            var argumentName = GetNameOfGenericArgument(2);

            //Assert
            Assert.True(name == argumentName);
        }

        [Fact]
        public void The_Name_Of_The_Fourth_Generic_Argument_Is_TEntity()
        {
            //Arrange
            var name = "TEntity";

            //Act
            var argumentName = GetNameOfGenericArgument(3);

            //Assert
            Assert.True(name == argumentName);
        }

        /// <summary>
        /// Returns the name of a generic argument
        /// </summary>
        /// <param name="numberOfArgument">Argument numbering starts at zero</param>
        /// <returns>Argument name</returns>
        public string GetNameOfGenericArgument(int numberOfArgument = 0)
        {
            var type = TypeOfCommandHandler();
            return type.GetGenericArguments()[numberOfArgument].Name;
        }

        [Fact]
        public void AwesomeCommandHandler_Inherit_From_DbCommandHandler()
        {
            //Arrange
            var type = typeof(CommandHandler<,>);

            var handler = typeof(DbCommandHandler<,,,>);

            //Act
            var result = handler.BaseType;

            //Assert
            Assert.True(type.Name == result.Name);
        }
    }
}
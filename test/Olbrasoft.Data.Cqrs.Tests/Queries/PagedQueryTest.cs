﻿using Olbrasoft.Dispatching.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Data.Cqrs.Queries
{
    public class PagedQueryTest : BaseTest
    {
        [Fact]
        public void Inherit_From_Request()
        {
            //Arrange
            var type = typeof(Request<object>);

            //Act
            var query = new PagedQuery<object>(DispatcherMock.Object);

            //Assert
            Assert.IsAssignableFrom(type, query);
        }
    }
}
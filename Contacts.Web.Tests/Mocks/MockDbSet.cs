using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Web.Tests.Async;
using Moq;

namespace Contacts.Web.Tests.Mocks
{
    internal sealed class MockDbSet<T> : Mock<DbSet<T>> where T : class
    {
        public MockDbSet(IQueryable<T> data, IEnumerable<int> ids)
        {
            As<IDbAsyncEnumerable<T>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<T>(data.GetEnumerator()));

            As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<T>(data.Provider));

            As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            Setup(m => m.FindAsync(It.IsNotIn(ids))).Returns(Task.FromResult<T>(null));
            Setup(m => m.FindAsync(It.IsIn(ids))).Returns(Task.FromResult(data.First()));
            Setup(x => x.Include(It.IsAny<string>())).Returns(Object);
        }
    }
}

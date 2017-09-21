using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication1.Data;
using WebApplication1.Service.Commands.Common;

namespace WebApplication1.Service.Tests.Commands.Common.SaveChangesCommandTests
{
    [TestClass]
    public abstract class SaveChangesCommandTestsBase
    {
        protected SaveChangesCommand Command;

        protected Mock<IDataSource> DataSource;

        [TestInitialize]
        public virtual void Arrange()
        {
            DataSource = new Mock<IDataSource>();

            Command = new SaveChangesCommand(
                DataSource.Object);
        }
    }
}

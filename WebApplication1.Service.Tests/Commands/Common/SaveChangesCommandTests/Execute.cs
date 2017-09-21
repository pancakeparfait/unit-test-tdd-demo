using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WebApplication1.Service.Tests.Commands.Common.SaveChangesCommandTests
{
    [TestClass]
    public class Execute : SaveChangesCommandTestsBase
    {
        private void Act()
        {
            Command.Execute();
        }

        [TestMethod]
        public void ShouldCallSaveChanges()
        {
            Act();

            DataSource.Verify(
                x => x.SaveChanges(),
                Times.Once);
        }
    }
}
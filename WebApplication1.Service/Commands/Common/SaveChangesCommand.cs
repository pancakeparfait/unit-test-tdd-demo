using WebApplication1.Data;

namespace WebApplication1.Service.Commands.Common
{
    public class SaveChangesCommand : ISaveChangesCommand
    {
        private readonly IDataSource _dataSource;

        public SaveChangesCommand(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public void Execute()
        {
            _dataSource.SaveChanges();
        }
    }
}
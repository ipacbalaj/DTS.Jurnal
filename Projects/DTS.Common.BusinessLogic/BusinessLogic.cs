using DSA.Database.Model.Helpers;
using DTS.Common.DatabaseServer;
namespace DTS.Common.BusinessLogic
{
    public class BusinessLogic
    {
        private static readonly BusinessLogic instance = new BusinessLogic();
        public static BusinessLogic Instance
        {
            get
            {
                return instance;
            }
        }

        public BusinessLogic()
        {
            Databasehandler = new LocalDatabaseHandler();
        }

        public IDatabasehandler Databasehandler { get; set; }

    }
}

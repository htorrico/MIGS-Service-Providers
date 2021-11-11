using Common;
using Common.Logging;

namespace Service.Base
{
    public class BaseService
    {
        public ICustomLog Logger { get; set; }
        protected readonly IConfigurationLib config;
        public ITransaction Transaction { get; set; }

        public BaseService(IConfigurationLib _config, ICustomLog _customLog)
        {
            config = _config;
            Logger = _customLog;
        }
    }
}

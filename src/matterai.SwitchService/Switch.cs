using System.Threading.Tasks;
using StackExchange.Redis;

namespace matterai.SwitchService
{
    public class Switch
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        
        public Switch(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<bool> IsEnabled(string keyName)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var value = await db.StringGetAsync(keyName);
            return !value.IsNullOrEmpty;
        }
    }
}
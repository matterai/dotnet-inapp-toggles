using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace matterai.SwitchService
{
    public class Switch
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        
        public Switch(IOptionsSnapshot<RedisOptions> options)
        {
            var o = options.Value;
            _connectionMultiplexer = ConnectionMultiplexer.Connect($"{o.Host}:{o.Port}");
        }

        public async Task<bool> IsEnabled(string keyName)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var value = await db.StringGetAsync(keyName);
            return !value.IsNullOrEmpty;
        }
    }
}
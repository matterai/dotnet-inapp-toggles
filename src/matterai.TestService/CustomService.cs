using System.Threading.Tasks;
using matterai.SwitchService;

namespace matterai.TestService
{
    public class CustomService
    {
        private readonly Switch _switch;

        private const string MyToggle = "my_toggle";
        
        public CustomService(Switch @switch)
        {
            _switch = @switch;
        }

        public async Task<string> GetGreetings(string name)
        {
            var isEnabled = await _switch.IsEnabled(MyToggle);
                
            return isEnabled 
                ? $"Hey, {name}! How are you?" 
                : $"Fuck you, {name}!";
        }
    }
}
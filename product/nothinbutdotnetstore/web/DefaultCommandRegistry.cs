using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        private IEnumerable<RequestCommand> _commands;
        public DefaultCommandRegistry(IEnumerable<RequestCommand> commands)
        {
            _commands = commands;
        }

        public RequestCommand get_the_command_that_can_process(Request request)
        {
            var cmd = from c in _commands
                      where c.can_process(request)
                      select c;
            return cmd.FirstOrDefault();

        }
    }
}
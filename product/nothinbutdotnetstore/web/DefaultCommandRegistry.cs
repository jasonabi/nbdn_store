using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> commands)
        {
            this.commands = commands;
        }

        public RequestCommand get_the_command_that_can_process(Request request)
        {
            return commands.First(x => x.can_process(request));

        }
    }
}
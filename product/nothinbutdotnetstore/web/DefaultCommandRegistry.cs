using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;
        MissingCommandFactory missing_command_factory;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> commands, MissingCommandFactory factory)
        {
            this.commands = commands;
            this.missing_command_factory = factory;
        }

        public RequestCommand get_the_command_that_can_process(Request request)
        {
            return commands.FirstOrDefault(x => x.can_process(request))
                ?? missing_command_factory.create();
        }
    }
}
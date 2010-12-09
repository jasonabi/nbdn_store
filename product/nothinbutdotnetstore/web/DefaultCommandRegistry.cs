using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;
        private MissingCommandFactory missingCommandFactory;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> commands, MissingCommandFactory factory)
        {
            this.commands = commands;
            this.missingCommandFactory = factory;
        }
        public RequestCommand get_the_command_that_can_process(Request request)
        {

            RequestCommand command = commands.FirstOrDefault(x => x.can_process(request));
            if (command == null)
                return missingCommandFactory.create();

            return command;

        }
    }
}
using System;

namespace nothinbutdotnetstore.web
{
    public class DefaultFrontController : FrontController
    {
        private CommandRegistry commandRegistry;

        public DefaultFrontController(CommandRegistry commandRegistry)
        {
            this.commandRegistry = commandRegistry;
        }

        public void process(Request request)
        {
            RequestCommand command = commandRegistry.get_the_command_that_can_process(request);
            command.process(request);
        }
    }
}
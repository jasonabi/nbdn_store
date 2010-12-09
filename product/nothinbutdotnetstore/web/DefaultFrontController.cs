namespace nothinbutdotnetstore.web
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry command_registry;

        public DefaultFrontController(CommandRegistry commandRegistry)
        {
            this.command_registry = commandRegistry;
        }

        public void process(Request request)
        {
            command_registry.get_the_command_that_can_process(request).process(request);
        }
    }
}
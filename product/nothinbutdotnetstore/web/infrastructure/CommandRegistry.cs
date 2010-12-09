namespace nothinbutdotnetstore.web.infrastructure
{
    public interface CommandRegistry
    {
        RequestCommand get_the_command_that_can_process(Request request);
    }
}
using System;

namespace nothinbutdotnetstore.web
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestSpecification request_specification;
        ApplicationCommand application_command;

        public DefaultRequestCommand(RequestSpecification request_specification, ApplicationCommand application_command)
        {
            this.request_specification = request_specification;
            this.application_command = application_command;
        }

        public void process(Request request)
        {
            application_command.process(request);
        }

        public bool can_process(Request request)
        {
            return request_specification(request);
        }
    }
}
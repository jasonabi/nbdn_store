using System;

namespace nothinbutdotnetstore.web
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestSpecification request_specification;

        public DefaultRequestCommand(RequestSpecification request_specification)
        {
            this.request_specification = request_specification;
        }

        public void process(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_process(Request request)
        {
            return request_specification(request);
        }
    }
}
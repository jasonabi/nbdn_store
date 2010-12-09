using System;

namespace nothinbutdotnetstore.web
{
    public class DefaultRequestCommand : RequestCommand
    {
        private RequestSpecification spec;

        public DefaultRequestCommand(RequestSpecification spec)
        {
            this.spec = spec;
        }

        public void process(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_process(Request request)
        {
            return spec(request);
        }
    }
}
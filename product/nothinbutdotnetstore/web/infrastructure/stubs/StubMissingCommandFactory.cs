using System;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubMissingCommandFactory : MissingCommandFactory
    {
        public RequestCommand create()
        {
            return new StubMissingCommand();
        }

        class StubMissingCommand : RequestCommand
        {
            public void process(Request request)
            {
                throw new NotImplementedException();
            }

            public bool can_process(Request request)
            {
                throw new NotImplementedException();
            }
        }
    }
}
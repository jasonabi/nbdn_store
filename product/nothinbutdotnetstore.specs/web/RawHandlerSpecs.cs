 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{   
    public class RawHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            RawHandler>
        {
        
        }

        [Subject(typeof(RawHandler))]
        public class when_processing_an_incoming_http_context : concern
        {
            Establish c = () =>
            {
                front_controller = the_dependency<FrontController>();
                request_factory = the_dependency<RequestFactory>();
                the_http_context = ObjectFactory.create_http_context();
                request = an<Request>();

                request_factory.Stub(x => x.create_from(the_http_context)).Return(request);
            };
        

            Because b = () =>
                sut.ProcessRequest(the_http_context);

            It should_delegate_the_processing_to_the_front_controller = () =>
                front_controller.received(x => x.process(request));

            static FrontController front_controller;
            static Request request;
            static HttpContext the_http_context;
            static RequestFactory request_factory;
        }
    }
}

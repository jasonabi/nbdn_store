using System.Web;
using nothinbutdotnetstore.stubs;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubRequestFactory : RequestFactory,AStub
    {
        public Request create_from(HttpContext the_http_context)
        {

            return new StubRequest();
        }

        class StubRequest : Request
        {
        }
    }
}
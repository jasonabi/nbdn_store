using System.Web;

namespace nothinbutdotnetstore.web
{
    public interface RequestFactory
    {
        Request create_from(HttpContext the_http_context);
    }
}
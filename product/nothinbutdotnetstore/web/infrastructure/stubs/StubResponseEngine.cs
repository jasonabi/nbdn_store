using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.stubs
{
    public class StubResponseEngine : ResponseEngine
    {
        public void prepare<ViewModel>(ViewModel model)
        {
            HttpContext.Current.Items.Add("blah",model);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx",true);
        }
    }
}
namespace nothinbutdotnetstore.web.infrastructure
{
    public interface ResponseEngine
    {
        void prepare<ViewModel>(ViewModel model);
    }
}
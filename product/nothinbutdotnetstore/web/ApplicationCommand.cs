namespace nothinbutdotnetstore.web
{
    public interface ApplicationCommand
    {
        void process(Request request);
    }
}
namespace nothinbutdotnetstore.web
{
    public interface RequestCommand 
    {
        void process(Request request);
        bool can_process(Request request);
    }
}
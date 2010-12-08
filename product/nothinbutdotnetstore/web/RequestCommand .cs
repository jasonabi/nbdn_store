namespace nothinbutdotnetstore.web
{
    public interface RequestCommand 
    {
        void process(Request request);
    }
}
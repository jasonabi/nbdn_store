namespace nothinbutdotnetstore.stubs
{
    public class Stub
    {
        public static ElementToStub with<ElementToStub>() where ElementToStub : AStub, new()
        {
            return new ElementToStub();
        }
    }
}
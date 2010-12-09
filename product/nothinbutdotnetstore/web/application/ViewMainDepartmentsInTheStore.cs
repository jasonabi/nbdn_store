using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        Repository repository;
        ResponseEngine response_engine;

        public ViewMainDepartmentsInTheStore():this(new StubRepository(),
            new StubResponseEngine())
        {
        }

        public ViewMainDepartmentsInTheStore(Repository repository, ResponseEngine response_engine)
        {
            this.repository = repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.prepare(repository.get_all_the_main_departments_in_the_store());
        }
    }
}
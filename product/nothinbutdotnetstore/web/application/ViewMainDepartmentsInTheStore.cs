using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        Repository repository;
        ResponseEngine response_engine;

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
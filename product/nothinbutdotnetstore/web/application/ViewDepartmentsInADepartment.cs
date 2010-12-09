using System;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDepartmentsInADepartment : ApplicationCommand
    {
        private Repository _repository;
        private ResponseEngine _responseEngine;

        public void process(Request request)
        {                        
            this._responseEngine.prepare(_repository.get_all_departments_in( request.map<Department>()));
        }

        public ViewDepartmentsInADepartment(Repository repository, ResponseEngine responseEngine)
        {
            _responseEngine = responseEngine;
            _repository = repository;
        }
    }
}
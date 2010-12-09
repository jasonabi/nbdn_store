using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewSubDepartmentsOfADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewSubDepartmentsOfADepartment>
        {
        }
        
        [Subject(typeof(ViewSubDepartmentsOfADepartment))]
        public class when_processing : concern
        {
            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                department_repository = the_dependency<Repository>();
                the_subdepartments = new List<Department>();
                request = an<Request>();
                department = an<Department>();

                department_repository.Stub(x => x.get_all_subdepartments_of_department(department)).Return(
                    the_subdepartments);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_to_display_the_subdepartments = () =>
                response_engine.received(x => x.prepare(the_subdepartments));

            static Repository department_repository;
            static Request request;
            static IEnumerable<Department> the_subdepartments;
            static ResponseEngine response_engine;
            static Department department;
        }
    }
}

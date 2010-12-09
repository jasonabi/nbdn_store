using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewDepartmentsInADepartment>
        {
        }

        [Subject(typeof(ViewDepartmentsInADepartment))]
        public class when_processing : concern
        {
            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                department_repository = the_dependency<Repository>();
                the_departments = new List<Department>();
                parent_department = new Department();
                request = an<Request>();

                request.Stub(x => x.map<Department>()).Return(
                    parent_department);

                department_repository.Stub(x => x.get_all_departments_in(parent_department)).Return(
                    the_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_to_display_the_departments_in_a_department = () =>
                response_engine.received(x => x.prepare(the_departments));

            static Repository department_repository;
            static Request request;
            static IEnumerable<Department> the_departments;
            static ResponseEngine response_engine;
            private static Department parent_department;
        }
    }
}
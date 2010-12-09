using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.tasks
{
    public interface Repository
    {
        IEnumerable<Department> get_all_the_main_departments_in_the_store();

        object get_all_subdepartments_of_department(Department department);
    }
}
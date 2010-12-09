using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubRepository : Repository
    {
        public IEnumerable<Department> get_all_the_main_departments_in_the_store()
        {
            return Enumerable.Range(1, 100).Select(x => new Department{name =  x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_all_departments_in(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
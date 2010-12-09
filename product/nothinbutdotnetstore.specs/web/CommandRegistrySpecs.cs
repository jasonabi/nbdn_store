 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{   
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<CommandRegistry,
                                            DefaultCommandRegistry>
        {
        
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_getting_a_command_that_can_process_a_request_and_it_has_the_command : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                the_command_that_can_process_the_request = an<RequestCommand>();
                all_the_commands = Enumerable.Range(1, 100).Select(x => an<RequestCommand>()).ToList();
                all_the_commands.Add(the_command_that_can_process_the_request);
                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_the_commands);

                the_command_that_can_process_the_request.Stub(x => x.can_process(request)).Return(true);
            };

            Because b = () =>
                result = sut.get_the_command_that_can_process(request);

            It should_return_the_command_to_the_caller = () =>
                result.ShouldEqual(the_command_that_can_process_the_request);

            static RequestCommand result;
            static RequestCommand the_command_that_can_process_the_request;
            static Request request;
            static List<RequestCommand> all_the_commands;
        }

        public class when_attempting_to_get_a_command_for_a_request_and_there_is_not_one : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                missing_command = an<RequestCommand>();
                missing_command_factory = the_dependency<MissingCommandFactory>();
                all_the_commands = Enumerable.Range(1, 100).Select(x => an<RequestCommand>()).ToList();
                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_the_commands);

                missing_command_factory.Stub(x => x.create()).Return(missing_command);
            };

            Because b = () =>
                result = sut.get_the_command_that_can_process(request);

            It should_return_the_command_to_the_caller = () =>
                result.ShouldEqual(missing_command);

            static RequestCommand result;
            static Request request;
            static List<RequestCommand> all_the_commands;
            static MissingCommandFactory missing_command_factory;
            static RequestCommand missing_command;
        }
    }
}

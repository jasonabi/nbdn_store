using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<RequestCommand,
                                            DefaultRequestCommand>
        {
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_determinining_if_it_can_process_a_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<RequestSpecification>(x =>
                {
                    was_called = true;
                    return true;
                });
            };

            Because b = () =>
                result = sut.can_process(request);

            It should_make_the_determination_by_using_its_request_specification = () =>
            {
                result.ShouldBeTrue();
                was_called.ShouldBeTrue();
            };

            static bool result;
            static Request request;
            static bool was_called;
        }
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                application_command = the_dependency<ApplicationCommand>();
            };

            Because b = () =>
                sut.process(request);


            It should_delegate_the_processing_to_the_application_specific_command = () =>
                application_command.received(x => x.process(request));

            static Request request;
            static ApplicationCommand application_command;
        }
    }
}
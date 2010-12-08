using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.concepts
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator>
        {
        }

        public class when_adding_two_positive_numbers_together : concern
        {
            Because b = () =>
                result = sut.add(2, 3);

            It should_return_the_some_of_the_two_numbers = () =>
                result.ShouldEqual(5);

            static int result;
        }

        public class when_attempting_to_add_and_one_of_the_number_is_negative : concern
        {
            Because b = () =>
                catch_exception(() => sut.add(2, -3));

            It should_throw_an_argument_exception = () =>
                exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();
        }


        public class when_shutting_off_the_calculator_and_they_are_in_the_correct_security_group : concern
        {
            Establish c = () =>
            {
                principal = an<IPrincipal>();
                principal.Stub(x => x.IsInRole(Arg<String>.Is.Anything)).Return(true);

                change(() => Thread.CurrentPrincipal).to(principal);
            };

            Because b = () =>
                sut.shut_off();

            It should_shut_off_the_calculator = () => { };
            static IPrincipal principal;
        }
        public class when_shutting_off_the_calculator_and_they_are_not_in_the_correct_security_group : concern
        {
            Establish c = () =>
            {
                principal = an<IPrincipal>();
                principal.Stub(x => x.IsInRole(Arg<String>.Is.Anything)).Return(false);

                change(() => Thread.CurrentPrincipal).to(principal);
            };

            Because b = () =>
                catch_exception(() => sut.shut_off());


            It should_throw_a_security_exception = () =>
                exception_thrown_by_the_sut.ShouldBeAn<SecurityException>();

            static IPrincipal principal;
        }
    }

    public class MyFakeConnection : IDbConnection
    {
        public bool was_opened;

        public MyFakeConnection(IDbCommand command_to_return)
        {
            this.command_to_return = command_to_return;
        }

        public bool was_disposed { get; set; }
        IDbCommand command_to_return;

        public void Dispose()
        {
            was_disposed = true;
        }

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public IDbCommand CreateCommand()
        {
            return command_to_return;
        }

        public void Open()
        {
            was_opened = true;
        }

        public string ConnectionString
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int ConnectionTimeout
        {
            get { throw new NotImplementedException(); }
        }

        public string Database
        {
            get { throw new NotImplementedException(); }
        }

        public ConnectionState State
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int number1, int number2)
        {
            ensure_neither_numbers_are_negative(number1, number2);
            return number1 + number2;
        }

        void ensure_neither_numbers_are_negative(int number1, int number2)
        {
            if (number1 < 0 || number2 < 0) throw new ArgumentException();
        }

        public void enter_scientific_mode()
        {
            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void shut_off()
        {
            ensure_is_in_correct_group();
        }

        void ensure_is_in_correct_group()
        {
            if (Thread.CurrentPrincipal.IsInRole("blah")) return;

            throw new SecurityException();

        }
    }
}
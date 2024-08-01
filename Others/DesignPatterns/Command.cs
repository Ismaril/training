// COMPLEXITY OF PATTERN: EASY
/*
Command is a behavioral design pattern that turns a request into a stand-alone
object that contains all information about the request. This transformation
lets you pass requests as a method arguments, delay or queue a request’s execution,
and support undoable operations.
*/
namespace DesignPatterns
{
    // The Command interface declares a method for executing a command.
    public interface ICommand
    {
        void Execute();
    }

    // Some commands can implement simple operations on their own,
    // meaning there is no need for receiver.
    class SimpleCommand(string payload) : ICommand
    {
        public void Execute() => Console.WriteLine($"SimpleCommand: \"{payload}\"");
    }

    // However, some commands can delegate more complex operations to other
    // objects, called "receivers."
    class ComplexCommand(Receiver receiver, string a, string b) : ICommand
    {
        // Commands can delegate to any methods of a receiver.
        public void Execute()
        {
            // ComplexCommand: Complex stuff will be done by a receiver object.
            receiver.DoSomething(a);
            receiver.DoSomethingElse(b);
        }
    }

    // The Receiver classes contain some important business logic. They know how
    // to perform all kinds of operations, associated with carrying out a
    // request. In fact, any class may serve as a Receiver.
    class Receiver
    {
        public void DoSomething(string task1)
        {
            Console.Write($"Receiver: Working on task1: \"{task1}\", ");
        }

        public void DoSomethingElse(string task2)
        {
            Console.Write($"Receiver: Working on task2: \"{task2}\" ");
        }
    }

    // The Invoker is associated with one or several commands. It sends a
    // request to the command.
    class Invoker
    {
        private ICommand _onStart;

        private ICommand _onFinish;

        // Initialize commands.
        public void SetOnStart(ICommand command) => _onStart = command;

        public void SetOnFinish(ICommand command) => _onFinish = command;

        // The Invoker does not depend on concrete command or receiver classes.
        // The Invoker passes a request to a receiver indirectly, by executing a
        // command.
        public void DoSomethingImportant()
        {
            // Invoker: Does anybody want something done before I begin?
            if (_onStart is ICommand)
                _onStart.Execute();

            Console.WriteLine("Invoker: Doing some logic");

            // Invoker: Does anybody want something done after I finish?
            if (_onFinish is ICommand)
                _onFinish.Execute();
        }
    }

    public class ProgramCommand
    {
        public static void Main__()
        {
            // The client code can parameterize an invoker with any commands.
            Invoker invoker = new();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            invoker.SetOnFinish(new ComplexCommand(
                new Receiver(), "Send email", "Save report"));

            // This invoker now contains two commands. One command will be executed
            // at the start of "DoSomethingImportant" and the other command will be
            // executed at the end. Since the first command is a simple command,
            // it does not pass anything to any receiver. The second command, however,
            // is a complex command that delegates the work to the receiver.
            // This means that we have a structure:
            // Invoker -> Command -> Receiver
            invoker.DoSomethingImportant();
        }
    }
}
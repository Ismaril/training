// COMPLEXITY OF PATTERN: MEDIUM


namespace DesignPatterns
{
    // The Handler interface declares a method for building the chain of
    // handlers. It also declares a method for executing a request.
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(object request);
    }

    // The default chaining behavior can be implemented inside a base handler
    // class.
    abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;

            // Returning a handler from here will let us link handlers in a
            // convenient way like this:
            // monkey.SetNext(squirrel).SetNext(dog);
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (_nextHandler != null)
                return _nextHandler.Handle(request);
            else
                return null;
        }
    }

    class MonkeyHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Banana")
                return $"Monkey: I'll eat the {request.ToString()}.\n";
            else
                return base.Handle(request);
        }
    }

    class SquirrelHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "Nut")
                return $"Squirrel: I'll eat the {request.ToString()}.\n";
            else
                return base.Handle(request);
        }
    }

    class DogHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "MeatBall")
                return $"Dog: I'll eat the {request.ToString()}.\n";
            else
                return base.Handle(request);
        }
    }

    class Client__
    {
        // The client code is usually suited to work with a single handler. In
        // most cases, it is not even aware that the handler is part of a chain.
        public static void ClientCode(AbstractHandler handler)
        {
            var list_ = new List<string> { "Nut", "Banana", "Cup of coffee", "MeatBall" };
            //var list_ = new List<string> { "MeatBall", "Cup of coffee", "Banana", "Nut" };

            foreach (var food in list_)
            {
                Console.WriteLine($"Client: Who wants a {food}?");

                var result = handler.Handle(food);

                if (result != null)
                    Console.Write($"\t{result}");
                else
                    Console.WriteLine($"\t{food} was left untouched.");
            }
        }
    }
    public class ProgramChainOfResponsibility
    {
        // In this example, we link together up to three objects/handlers. It
        // is done it a nested way. This means that each handler has a field
        // "_nextHandler" which holds another handler which has the same filed
        // which holds another handle (and it could continue on and on). If
        // a desired request is not handled by the first handler, it is passed
        // to the next handler and so on. In this case the result is then
        // propagated back from the lowest handler up (if it was not handled in
        // the handlers in upper layers in the first place).
        // In case it is unclear, debug it and you will see how it works.
        public static void Main__()
        {
            // The other part of the client code constructs the actual chain.
            MonkeyHandler monkey = new();
            SquirrelHandler squirrel = new();
            DogHandler dog = new();

            // If you are confused what does this dot syntax do, checkout the
            // two commented lines below.
            monkey.SetNext(squirrel).SetNext(dog);
            //squirrel = (SquirrelHandler)monkey.SetNext(squirrel);
            //dog = (DogHandler)squirrel.SetNext(dog);

            // The client should be able to send a request to any handler, not
            // just the first one in the chain.
            Console.WriteLine("Chain: Monkey -> Squirrel -> Dog\n");
            Client__.ClientCode(monkey);

            ConsoleOutputSeparator.Separator();

            Console.WriteLine("Subchain: Squirrel -> Dog\n");
            Client__.ClientCode(squirrel);

            ConsoleOutputSeparator.Separator();

            // There is just dog, no other handler after it.
            Console.WriteLine("Subchain: Dog\n");
            Client__.ClientCode(dog);
        }
    }
}
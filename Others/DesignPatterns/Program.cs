namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CREATIONAL PATTERNS
            // These patterns provide various object creation mechanisms,
            // which increase flexibility and reuse of existing code.
            //ProgramFactoryMethod.Main__();
            //ProgramAbstractFactory.Main__();
            //ProgramBuilder.Main__();
            //ProgramPrototype.Main__();
            //ProgramSingleton.Main__();

            // STRUCTURAL PATTERNS
            // These patterns explain how to assemble objects and classes
            // into larger structures while keeping these structures
            // flexible and efficient.
            //ProgramAdapter.Main__();
            //ProgramDecorator.Main__();
            //ProgramFacade.Main__();
            //ProgramProxy.Main__();
            //ProgramComposite.Main__();
            //ProgramBridge.Main__(); --> Needs better explanation in my project.
            ProgramFlyweight.Main__();

            // BEHAVIORAL PATTERNS
            // These patterns are concerned with algorithms and
            // the assignment of responsibilities between objects.
            //ProgramChainOfResponsibility.Main__();
            //ProgramCommand.Main__();
            //ProgramIterator.Main__();
            //ProgramMediator.Main__();
            //ProgramState.Main__();
            //...
            //...

            Console.ReadLine();

        }
    }
}

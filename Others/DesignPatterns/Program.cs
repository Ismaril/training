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
            //ProgramBridge.Main__(); --> X
            //ProgramFlyweight.Main__();

            // BEHAVIORAL PATTERNS
            // These patterns are concerned with algorithms and
            // the assignment of responsibilities between objects.
            //ProgramChainOfResponsibility.Main__();
            //ProgramIterator.Main__();
            //ProgramCommand.Main__(); --> X
            //ProgramTemplateMethod.Main__();
            //ProgramMediator.Main__(); --> X
            //ProgramState.Main__();
            //ProgramMemento.Main__(); --> X
            //ProgramStrategy.Main__();
            //ProgramVisitor.Main__(); --> X
            ProgramObserver.Main__();

            Console.ReadLine();

        }
    }
}

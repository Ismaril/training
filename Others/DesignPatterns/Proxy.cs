﻿namespace DesignPatterns
{
    // The Subject interface declares common operations for both RealSubject and
    // the Proxy. As long as the client works with RealSubject using this
    // interface, you'll be able to pass it a proxy instead of a real subject.
    public interface ISubject
    {
        void Request();
    }

    // The RealSubject contains some core business logic. Usually, RealSubjects
    // are capable of doing some useful work which may also be very slow or
    // sensitive - e.g. correcting input data. A Proxy can solve these issues
    // without any changes to the RealSubject's code.
    class RealSubject : ISubject
    {
        public void Request() => Console.WriteLine("RealSubject: Handling Request.");
    }

    // The Proxy has an interface identical to the RealSubject.
    class Proxy(RealSubject realSubject) : ISubject
    {

        // The most common applications of the Proxy pattern are lazy loading,
        // caching, controlling the access, logging, etc. A Proxy can perform
        // one of these things and then, depending on the result, pass the
        // execution to the same method in a linked RealSubject object.
        public void Request()
        {
            if (CheckAccess())
            {
                realSubject.Request();
                LogAccess();
            }
        }

        public bool CheckAccess()
        {
            // Some real checks should go here.
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");
            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }

    public class Client____
    {
        // The client code is supposed to work with all objects (both subjects
        // and proxies) via the Subject interface in order to support both real
        // subjects and proxies. In real life, however, clients mostly work with
        // their real subjects directly. In this case, to implement the pattern
        // more easily, you can extend your proxy from the real subject's class.
        public void ClientCode(ISubject subject)
        {
            // ...

            subject.Request();

            // ...
        }
    }

    public class ProgramProxy
    {
        public static void Main__()
        {
            Client____ client = new();
            RealSubject realSubject = new();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            client.ClientCode(realSubject);


            ConsoleOutputSeparator.Separator();


            Proxy proxy = new (realSubject);
            Console.WriteLine("Client: Executing the same client code with a proxy:");
            client.ClientCode(proxy);
        }
    }
}
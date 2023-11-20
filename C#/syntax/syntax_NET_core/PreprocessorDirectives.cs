// Uncomment if you do not have it defined in configuration manager.
//# define TRIAL 

# define RELEASE

namespace syntax_NET_core
{
    internal static class PreprocessorDirectives
    {
        public static void Main__()
        {
            // This code block will be compiled only if the Trial is defined
            //  at the top of this file.
            // Also this Trial must be defined in every file where you want to use it.
            // But it is better idea to define it in the options, you can do it
            //  in the box where you see Debug or Release. Just add new configuration.
#if TRIAL
            Console.WriteLine("Trial version");
#endif

            // Conditional compilation
#if ENTERPRISE
            Console.WriteLine("Enterprise version");
#elif PROFESSIONAL
            Console.WriteLine("Professional version");
#endif

#if ENTERPRISE || PROFFESIONAL
            Console.WriteLine("You got it all");
#endif
            // Warning directive
#if DEBUG && RELEASE
#warning "You cannot define both DEBUG and RELEASE"
#endif
            // Error directive
#if TRIAL && RELEASE
#line 100 // You can specify the line number which will be shown along error msg.
#error "You cannot define both DEBUG and RELEASE" 
#endif
        }

        // You can use conditional attribute to mark a
        //  method that should be called only in debug mode for example.
        [System.Diagnostics.Conditional("DEBUG")]
        static void WriteShit(string message)
        {
            Console.WriteLine(message);
        }
    }
}

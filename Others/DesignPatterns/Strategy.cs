//             +-----------------------------------------+
//             |   <<interface>> ICompressionStrategy    |
//             | ----------------------------------------|
//             | +Compress(filePath: string): void       |
//             +-----------------------------------------+
//                                  ^
//                    implements    |
//                     +------------+------------+
//                     |                         |
//+-----------------------------------+   +-----------------------------------+
//|          ZipCompressionStrategy   |   |         RarCompressionStrategy    |
//+-----------------------------------+   +-----------------------------------+
//| + Compress(filePath: string): void|   | + Compress(filePath: string): void|
//+-----------------------------------+   +-----------------------------------+
//
//
//          +-----------------------------------------------+
//          |                 FileCompressor                |
//          +-----------------------------------------------+
//          | - _compressionStrategy: ICompressionStrategy  |
//          + ----------------------------------------------+
//          | +FileCompressor(ICompressionStrategy)         |
//          | +SetCompressionStrategy(ICompressionStrategy) |
//          | +CompressFile(filePath: string): void         |
//          +-----------------------------------------------+
//                                 ^
//                                 | uses
//                                 |
//              +--------------------------------------+
//              |               Program                |
//              +--------------------------------------+
//              | + Main(args: string[]): void         |
//              +--------------------------------------+

namespace DesignPatterns
{
    // -----------------------------------------------------------------------------------------------------------
    // 1. DEFINE THE STRATEGY INTERFACE
    public interface ICompressionStrategy
    {
        void Compress(string filePath);
    }

    // -----------------------------------------------------------------------------------------------------------
    // 2. IMPLEMENT CONCRETE STRATEGIES
    public class ZipCompressionStrategy : ICompressionStrategy
    {
        public void Compress(string filePath)
        {
            // Implementation for ZIP compression
            Console.WriteLine($"Compressing '{filePath}' using ZIP.");
            // Actual ZIP compression logic goes here
        }
    }

    public class RarCompressionStrategy : ICompressionStrategy
    {
        public void Compress(string filePath)
        {
            // Implementation for RAR compression
            Console.WriteLine($"Compressing '{filePath}' using RAR.");
            // Actual RAR compression logic goes here
        }
    }

    public class AnyOtherCompressionStrategy : ICompressionStrategy
    {
        public void Compress(string filePath)
        {
            // ...
        }
    }

    // -----------------------------------------------------------------------------------------------------------
    // 3. CREATE THE CONTEXT CLASS
    public class FileCompressor
    {
        private ICompressionStrategy _compressionStrategy;

        // You can inject the strategy through the constructor, a setter, or any method.
        public FileCompressor(ICompressionStrategy compressionStrategy)
        {
            _compressionStrategy = compressionStrategy;
        }

        public void SetCompressionStrategy(ICompressionStrategy compressionStrategy)
        {
            _compressionStrategy = compressionStrategy;
        }

        public void CompressFile(string filePath)
        {
            // Delegate the actual work to the strategy
            _compressionStrategy.Compress(filePath);
        }
    }


    // -----------------------------------------------------------------------------------------------------------
    // CLINET CODE
    public static class ProgramStrategy
    {
        public static void Main__()
        {
            // Choose a strategy at runtime
            ICompressionStrategy zipStrategy = new ZipCompressionStrategy();
            FileCompressor fileCompressor = new FileCompressor(zipStrategy);

            fileCompressor.CompressFile("C:\\files\\mydocument.docx");

            // Switch strategy at runtime, if desired
            ICompressionStrategy rarStrategy = new RarCompressionStrategy();
            fileCompressor.SetCompressionStrategy(rarStrategy);

            fileCompressor.CompressFile("C:\\files\\mydocument.docx");
        }
    }
}

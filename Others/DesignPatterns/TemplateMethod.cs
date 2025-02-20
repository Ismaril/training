using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

// Template Method is a behavioral design pattern that defines the skeleton of an
// algorithm in the superclass but lets subclasses override specific steps of the
// algorithm without changing its structure.
namespace DesignPatterns
{
    // --------------------------------------------------------------------------------
    // 1. CREATE AN ABSTRACT CLASS THAT DEFINES A TEMPLATE METHOD
    abstract class DigitExtractor
    {
        protected string extractedCompleteText;
        protected string extractedDigits;
        protected string _path;
        protected string digits;

        // The template method defines the skeleton of a process / algorithm.
        // It contains unique steps that are available to all subclasses.
        // Often all those "Step" methods are abstract and must be implemented by subclasses.
        // For our demonstration only one method is abstract and others are optional to override.
        public void ProcessData()
        {
            ReadFile(_path);
            ExtractDigits();
            SumDigits();
            SaveResults();
            NotifyThatJobDone();
        }

        protected abstract void ReadFile(string path);

        // Optional hook method
        public virtual void SumDigits()
        {

        }

        void ExtractDigits()
        {
            Console.WriteLine("Extracting digits.");

            foreach (char c in extractedCompleteText)
            {
                if (char.IsDigit(c))
                    digits += c;
            }
        }

        void SaveResults()
        {
            Console.WriteLine("Results saved.");

            if (digits is null)
                Console.WriteLine("No digits found.");
            else
                Console.WriteLine($"Extracted digits: {digits}");
        }

        protected virtual void NotifyThatJobDone()
        {
            Console.WriteLine("Job done. Reports/Mails sent to all.");
        }

    }

    // --------------------------------------------------------------------------------
    // 2. CREATE CONCRETE CLASSES
    class TextFileDigitExtractor : DigitExtractor
    {
        public TextFileDigitExtractor(string path)
        {
            _path = path;
        }
        protected override void ReadFile(string path)
        {
            Console.WriteLine("Reading text file.");
            extractedCompleteText = File.ReadAllText(path);
        }

        public override void SumDigits()
        {
            if (digits is null)
                return;

            int result = 0;
            foreach (char c in digits)
            {
                result += int.Parse(c.ToString());
            }
            Console.WriteLine($"Sum of numbers: {result}");
        }

        protected override void NotifyThatJobDone()
        {
            Console.WriteLine("Job done. Reports/Mails sent to guys responsible for Text files.");
        }
    }

    class WordFileDigitExtractor : DigitExtractor
    {
        public WordFileDigitExtractor(string path)
        {
            _path = path;
        }

        protected override void ReadFile(string path)
        {
            Console.WriteLine("Reading Word file.");
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, false))
            {
                // Get the main document part
                Body body = wordDoc.MainDocumentPart.Document.Body;

                extractedCompleteText = body.InnerText;
            }
        }
    }

    // --------------------------------------------------------------------------------
    // CLIENT CODE
    public class ProgramTemplateMethod
    {
        public static void Main__()
        {
            // Example of polymorphism in action. On the same interface/object (DigitExtractor)
            // we call the same method, but different implementations are executed.

            const string PATH_TO_FILES = @"..\..\..\files\";

            string textFile = PATH_TO_FILES + "1.txt";
            DigitExtractor textFileDigitExtractor = new TextFileDigitExtractor(textFile);
            textFileDigitExtractor.ProcessData();

            ConsoleOutputSeparator.Separator();

            string document = PATH_TO_FILES + "2.docx";
            DigitExtractor wordFileDigitExtractor = new WordFileDigitExtractor(document);
            wordFileDigitExtractor.ProcessData();

        }
    }
}

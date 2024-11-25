/*
Flyweight is a structural design pattern that lets you fit more objects into the available amount
of RAM by sharing common parts of STATE between multiple objects instead of keeping all of the
data in each object.

Common usage:
GUIs - Text editors, Repeated UI elements like buttons, icons, widgets.
Games - Repeated game objects like bullets, enemies, etc.
Any other application where it makes sense to share the state of objects, or where objects are expensive to create.
 */
namespace DesignPatterns
{
    // ---------------------------------------------------------------------------------------------------------------------------
    // 1.FLYWEIGHT INTERFACE
    public interface ICharacter
    {
        void Render(int position);
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    // 2. CONCRETE FLYWEIGHT
    // Intrinsic state = Intrinsic in this sense mean that the state is shared among more objects.
    public class CustomCharacter : ICharacter
    {
        private readonly char _symbol;     // Intrinsic state
        private readonly ConsoleColor _color; // Intrinsic state

        public CustomCharacter(char symbol, ConsoleColor color)
        {
            _symbol = symbol;
            _color = color;
        }

        public void Render(int position)
        {
            // Use the extrinsic state (positionInText) to render the customChar
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(position, Console.CursorTop);
            Console.Write(_symbol);
            Console.ResetColor();
        }
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    // 3a. FLYWEIGHT CHARACTER FACTORY
    public class FlyweightCharacterFactory: IFactory
    {
        public Dictionary<string, ICharacter> CharactersKeyworded { get; set; } = new();
        public List<ICharacter> Characters { get; set; } = new();

        public ICharacter GetCharacter(char symbol, ConsoleColor color)
        {
            string key = $"{symbol}-{color}";
            if (!CharactersKeyworded.ContainsKey(key))
            {
                CharactersKeyworded[key] = new CustomCharacter(symbol, color);
                Characters.Add(CharactersKeyworded[key]);
            }
            return CharactersKeyworded[key];
        }
    }

    // 3b. INEFFICIENT CHARACTER FACTORY (Here in this file, it is just for comparison with flyweight, otherwise it has no meaning)
    public class InefficientCharacterFactory: IFactory
    {
        public List<ICharacter> Characters { get; set; } = new();
        public ICharacter GetCharacter(char symbol, ConsoleColor color)
        {
            ICharacter character = new CustomCharacter(symbol, color);
            Characters.Add(character);
            return character;
        }
    }

    // Helper Interface (Not part of the pattern)
    public interface  IFactory
    {
        public ICharacter GetCharacter(char symbol, ConsoleColor color);
        /// <summary>
        /// To get the characters/objects created. (In the end we are interested in the number of unique objects created)
        /// </summary>
        public List<ICharacter> Characters { get; set; }
    }

    // ---------------------------------------------------------------------------------------------------------------------------
    // 4. CLIENT CODE
    public class ProgramFlyweight
    {
        private static List<ICharacter> ClientCode(string docText, IFactory factory)
        {
            List<ICharacter> docTextFormatted = new();
            ConsoleColor color;
            int positionInText = 0;
            foreach (char char_ in docText)
            {
                const char CChar = 'C';
                const char hashChar = '#';

                // If else statement to decide a color of character
                if ((docText[docText.IndexOf(char_)] == CChar && docText[docText.IndexOf(char_) + 1] == hashChar)
                    || (positionInText >= 1 && docText[docText.IndexOf(char_) - 1] == CChar && docText[docText.IndexOf(char_)] == hashChar)
                    && positionInText < docText.Length - 1)
                    color = ConsoleColor.Red;
                else
                    color = ConsoleColor.White;

                // Get the shared customChar object, in case of flyweight factory. Else just return new object.
                ICharacter customChar = factory.GetCharacter(char_, color);

                // Display the customChar with extrinsic state
                customChar.Render(positionInText);
                docTextFormatted.Add(customChar);
                positionInText++;
            }
            Console.WriteLine($"\nNumber of unique objects:{factory.Characters.Count}");
            return docTextFormatted;
        }

        public static void Main__()
        {
            string text = "Programming in C#! Yes, C# is fun.";

            Console.WriteLine("FLYWEIGHT PATTERN (EFFICIENT MEMORY)");
            List<ICharacter> docTextFormatted = ClientCode(text, new FlyweightCharacterFactory());
            // See that the objects created using flyweight factory are the same:
            // Both the "C" custom characters are actually the same object
            Console.WriteLine("\n\nTWO LETTERS WHICH ARE VISIBLY THE SAME ARE IN FACT THE SAME OBJECTS:");
            Console.WriteLine(docTextFormatted[15].GetHashCode() == docTextFormatted[24].GetHashCode());

            Console.WriteLine(String.Concat(Enumerable.Repeat("-", 80)));

            Console.WriteLine("CREATING A NEW OBJECT FOR EACH LETTER");
            List<ICharacter> docTextFormattedInefficient = ClientCode(text, new InefficientCharacterFactory());
            Console.WriteLine(docTextFormattedInefficient[15].GetHashCode() == docTextFormattedInefficient[24].GetHashCode());
        }

        // NOTE: In practice of text editors, the intrinsic state is a character but the color is extrinsic state.
        // Just for info, in case you were wondering. In this case I decided to make the color intrinsic.
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// COMPLEXITY OF PATTERN: EASY

namespace DesignPatterns
{
    // ---------------------------------------------------------------------------------
    // 1. Define the Command Interface
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    // ---------------------------------------------------------------------------------
    // 2. CREATE CONCRETE COMMANDS
    public class LightOnCommand(Light light) : ICommand
    {
        public void Execute() => light.On();
        public void Undo() => light.Off();
    }

    public class LightOffCommand(Light light) : ICommand
    {
        public void Execute() => light.Off();
        public void Undo() => light.On();
    }

    // ---------------------------------------------------------------------------------
    // 3. DEFINE THE RECEIVER
    public class Light
    {
        public void On() => Console.WriteLine("The light is on");
        public void Off() => Console.WriteLine("The light is off");
    }

    // ---------------------------------------------------------------------------------
    // 4. DEFINE THE INVOKER
    public class RemoteControl
    {
        private ICommand _command;
        public void SetCommand(ICommand command) => _command = command;
        public void PressButton() => _command.Execute();
        public void PressUndo() => _command.Undo();
    }

    public class ProgramCommand
    {
        public static void Main__()
        {
            // Create the receiver
            Light livingRoomLight = new();

            // Create commands
            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            // Create invoker
            RemoteControl remote = new();

            // Turn the light on
            remote.SetCommand(lightOn);
            remote.PressButton(); // Output: The light is on

            // Turn the light off
            remote.SetCommand(lightOff);
            remote.PressButton(); // Output: The light is off

            // Undo the last action
            remote.PressUndo(); // Output: The light is on
        }
    }
}

/*
COMPLEXITY OF PATTERN: EASY
The pattern extracts state-related behaviors into separate state classes and forces the original object
to delegate the work to an instance of these classes, instead of acting on its own.
 */

//using static DesignPatterns.StateResolver;

namespace DesignPatterns
{
#if false
    // -----------------------------------------------------------------------------------------------------------
    // PROBLEM EXAMPLE
    // Since this "problem" code is very simple, it is not that much of a problem to use this option in practice.
    // However, if we wanted to use similar logic in bigger codebase, it might make sense to use the State pattern.
    public enum LightColor
    {
        Red,
        Green,
        Yellow
    }

    public class TrafficLight
    {
        private LightColor _currentColor;

        public TrafficLight()
        {
            // Default to Green
            _currentColor = LightColor.Green;
        }

        public void Change()
        {
            switch (_currentColor)
            {
                case LightColor.Red:
                    Console.WriteLine("Green...");
                    #region
                    // Huge business logic here
                    //...
                    //...
                    if (true)
                    {
                        // Do something
                        #region
                        // Some sub-logic here
                        //...
                        //...
                        #endregion
                    }
                    //
                    #endregion
                    _currentColor = LightColor.Green;
                    break;

                case LightColor.Green:
                    Console.WriteLine("Yellow...");
                    #region
                    // Huge business logic here
                    //...
                    //...
                    //
                    #endregion
                    _currentColor = LightColor.Yellow;
                    break;

                case LightColor.Yellow:
                    Console.WriteLine("Red...");
                    #region
                    // Huge business logic here
                    //...
                    //...
                    //
                    #endregion
                    _currentColor = LightColor.Red;
                    break;
            }
        }
    }
    #endif
    #if true
    // -----------------------------------------------------------------------------------------------------------
    // SOLUTION EXAMPLE (STATE PATTERN)
    public interface IColorState // <-- This one is gonna be inherited by the Red/Yellow/Green state classes.
    {
        void Handle(TrafficLight trafficLight, IColorState nextState);
    }

    /// <summary>
    /// StateResolver is used to determined what state/color to transition to next.
    /// </summary>
    public class StateResolver
    {
        IColorState _originalState;
        IColorState redState;
        IColorState yellowState;
        IColorState greenState;

        public StateResolver(IColorState state)
        {
            _originalState = state;
            redState = new RedState();
            yellowState = new YellowState();
            greenState = new GreenState();
        }

        public IColorState? Resolve()
        {
            switch (_originalState)
            {
                case RedState:
                    return greenState;
                case YellowState:
                    return redState;
                case GreenState:
                    return yellowState;
            }
            return null;
        }
    }
    public class RedState : IColorState
    {
        private void SomeMethodThatSolvesLogicOnlyInRedState1() { }
        private void SomeMethodThatSolvesLogicOnlyInRedState2() { }
        public void Handle(TrafficLight trafficLight, IColorState nextState)
        {
            Console.WriteLine("Red...");
            #region
            // Huge business logic here
            SomeMethodThatSolvesLogicOnlyInRedState1();
            SomeMethodThatSolvesLogicOnlyInRedState2();
            #endregion
            trafficLight.CurrentState = nextState;
        }
    }
    public class YellowState : IColorState
    {
        public void Handle(TrafficLight trafficLight, IColorState nextState)
        {
            Console.WriteLine("Yellow...");
            // Huge business logic here relevant for Yellow state
            trafficLight.CurrentState = nextState;
        }
    }
    public class GreenState : IColorState
    {
        public void Handle(TrafficLight trafficLight, IColorState nextState)
        {
            Console.WriteLine("Green...");
            trafficLight.CurrentState = nextState;
        }
    }

    // This the context class within which we hold the state and delegate the behavior to Change/Handle method.
    public class TrafficLight
    {
        public IColorState CurrentState { get; set; }
        public StateResolver StateResolver { get; set; }

        public TrafficLight()
        {
            // Default to Green when first initialized
            CurrentState = new GreenState();
        }

        public void Change()
        {
            // Chose which state/color to transition to.
            StateResolver = new StateResolver(CurrentState);

            // Delegate the state transition to the current state
            CurrentState.Handle(trafficLight: this, nextState: StateResolver.Resolve());
        }
    }
#endif
    // -----------------------------------------------------------------------------------------------------------
    // CLIENT CODE
    public class ProgramState
    {
        public static void Main__()
        {
            TrafficLight trafficLight = new();

            while (true)
            {
                trafficLight.Change();
                Thread.Sleep(1000);
            }
        }
    }

    // ADVANTAGES
    // 1. Single Responsibility Principle. Organize the code related to particular states into separate classes.
    // 2. Open/Closed Principle. Introduce new states without changing existing state classes or the context.

    // DISADVANTAGES
    // Overkill for a simple applications.

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// COMPLEXITY OF PATTERN: MEDIUM
/*
Composite is a structural design pattern that lets you compose objects into tree structures
and then work with these structures as if they were individual objects.

Using the Composite pattern makes sense only when the core model of your app can be
represented as a tree.


          object1
         /      \
    object2    object3
     /    \
object4  object5


 */

namespace DesignPatterns
{
    // ---------------------------------------------------------------------------
    // 1. DEFINE INTERFACE / ABSTRACT CLASS
    // The base Component class declares common operations for both simple and
    // complex objects of a composition.
    abstract class Component_
    {
        public Component_() { }

        // The base Component may implement some default behavior or leave it to
        // concrete classes (by declaring the method containing the behavior as
        // "abstract").
        public abstract string Operation();

        // In some cases, it would be beneficial to define the child-management
        // operations right in the base Component class. This way, you won't
        // need to expose any concrete component classes to the client code,
        // even during the object tree assembly. The downside is that these
        // methods will be empty for the component1-level components.
        public virtual void Add(Component_ component) => throw new NotImplementedException();

        public virtual void Remove(Component_ component) => throw new NotImplementedException();

        // You can provide a method that lets the client code figure out whether
        // a component can bear children.
        public virtual bool IsComposite() => true;
    }

    // -------------------------------------------------------------------------------
    // 2. COMPOSITE
    // The Composite class represents the complex components that may have
    // children. Usually, the Composite objects delegate the actual work to
    // their children and then "sum-up" the result.
    class Composite : Component_
    {
        protected List<Component_> _children = [];

        public override void Add(Component_ component) => _children.Add(component);

        public override void Remove(Component_ component) => _children.Remove(component);

        // The Composite executes its primary logic in a particular way. It
        // traverses recursively through all its children, collecting and
        // summing their results. Since the composite's children pass these
        // calls to their children and so forth, the whole object tree is
        // traversed as a result.
        public override string Operation()
        {
            int i = 0;
            string result = "Branch(";

            foreach (Component_ component in _children)
            {
                result += component.Operation();
                if (i != _children.Count - 1)
                    result += "+";
                i++;
            }
            return result + ")";
        }
    }

    // -------------------------------------------------------------------------
    // 3. LEAF
    // The Leaf class represents the end objects of a composition. A component1 can't
    // have any children.
    //
    // Usually, it's the Leaf objects that do the actual work, whereas Composite
    // objects only delegate to their sub-components.
    class Leaf : Component_
    {
        public override string Operation() => "Leaf";

        public override bool IsComposite() => false;
    }

    // ------------------------------------------------------------------------
    // 4. CLIENT CODE
    class ClientCode
    {
        // The client code works with all of the components via the base
        // interface.
        public void ClientCode_1(Component_ component1)
        {
            Console.WriteLine($"RESULT: {component1.Operation()}\n");
        }

        // Thanks to the fact that the child-management operations are declared
        // in the base Component class, the client code can work with any
        // component, simple or complex, without depending on their concrete
        // classes.
        public void ClientCode_2(Component_ component1, Component_ component2)
        {
            if (component1.IsComposite())
                component1.Add(component2);

            Console.WriteLine($"RESULT: {component1.Operation()}");
        }
    }

    public class ProgramComposite
    {
        public static void Main__()
        {
            ClientCode client = new();

            // This way the client code can support the simple component1
            // components...
            Leaf leaf = new();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode_1(leaf);

            // ...as well as the complex composites.
            Composite tree = new();
            Composite branch1 = new();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            Composite branch2 = new();
            branch2.Add(new Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            Console.WriteLine("Client: Now I've got a composite tree:");
            client.ClientCode_1(tree);

            client.ClientCode_2(tree, leaf);
        }
    }
}


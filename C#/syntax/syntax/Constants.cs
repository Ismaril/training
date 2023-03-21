using System;
using System.IO;
using System.Reflection;

namespace syntax
{
    internal static class Constants
    {
        // It will return full path ending in "..\bin\debug".
        internal static string workingDirectory = Environment.CurrentDirectory;

        // This will return the full path ending with most upper directory of our project.
        // Parent methods will do the same as in cmd "cd .."
        internal static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        // Get all directories. (Iterate over it and print it or debug it if you wanna see the output)
        internal static string[] projectDirectories = Directory.GetDirectories(
            path:projectDirectory,  // path from where to start looking
            searchPattern:"*",  // "*" asterisk as search for any??
            searchOption:SearchOption.AllDirectories); // All directories = seach all floders below current level. TopDirectoriesOnly = search only at current level (default).


    }
}

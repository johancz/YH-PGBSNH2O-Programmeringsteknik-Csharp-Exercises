using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Large_Exercise__To_Do_list
{
    public class Program
    {
        static List<string> Tasks = new List<string>();

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            MainMenu();
        }

        private static void MainMenu()
        {
            int menu_main_selected = ShowMenu("ToDoOrNotTo", new[]
            {
                "Add Task",                 // [0] // Task content and colour.
                "Edit Task",                // [1] // Task content and colour.
                "Complete Task",            // [2]
                "\"Un\"complete Task",      // [3]
                "Delete Task",              // [4]
                "---",                      // [5]
                "List Tasks",               // [6]
                "Search Tasks",             // [7]
                "Sort Tasks",               // [8] // Added, Name?, Content?, Colour?, Completed?
                "---",                      // [9]
                "Add User",                 // [10]
                "Change User",              // [11]
                "Remove User",              // [12]
                "---",                      // [13]
                "Save to File",             // [14] // Auto? 
                "Load / Import from File"   // [15] // Auto? 
            });

            switch (menu_main_selected)
            {
                case 0:
                    Program.AddTask();
                    break;
                case 1:
                    Program.EditTask();
                    break;
                case 2:
                    //Program.ListTasks();
                    break;
                case 3: break;
                case 4: break;
                case 6:
                    Program.ListTasks();
                    break;
                case 7: break;
                case 9: break;
                case 10: break;
                case 11: break;
                case 13: break;
                case 14: break;
                // Separators:
                case 5: break;
                case 8: break;
                case 12: break;
            }

            MainMenu();
        }

        private static int selectTask()
        {
            return ShowMenu("ToDoOrNotTo", Program.Tasks.ToArray());
        }
        private static void AddTask()
        {
            string newTask = ConsoleHelper.ReadString("Add new Task:");
            Program.Tasks.Add(newTask);
            //
        }
        private static void EditTask()
        {
            int selectedIndex = Program.selectTask();
            string newTask = ConsoleHelper.ReadString("Add new Task:");
            Program.Tasks[selectedIndex] = newTask;
            //
        }
        private static void DeleteTask()
        {
            int selectedIndex = Program.selectTask();
            Program.Tasks.RemoveAt(selectedIndex);
        }
        private static void ListTasks()
        {
            int selectedIndex = Program.selectTask();
        }

        // Add 'selected' param.
        public static int ShowMenu(string prompt, string[] options)
        {
            int longestMenuItem = options.Max(s => s.Length);
            string separator = new string('-', longestMenuItem);

            if (options == null || options.Length == 0)
            {
                throw new ArgumentException("Cannot show a menu for an empty array of options.");
            }

            Console.WriteLine(prompt);

            int selected = 0;
            bool selectedIsSeparator = false;

            // Hide the cursor that will blink after calling ReadKey.
            Console.CursorVisible = false;

            ConsoleKey? key = null;
            while (!(key == ConsoleKey.Enter && !selectedIsSeparator))
            {
                //if ConsoleKey.Enter && !selectedIsSeparator) {
                //    break;
                //}

                // If this is not the first iteration, move the cursor to the first line of the menu.
                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }

                // Print all the options, highlighting the selected one.
                for (int i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (option == "---")
                    {
                        Console.WriteLine(separator);
                    }
                    else
                    {
                        Console.WriteLine("- " + option);
                    }
                    Console.ResetColor();
                }

                // Read another key and adjust the selected value before looping to repeat all of this.
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Length - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }

                selectedIsSeparator = (options[selected] == "---") ? true : false;
            }

            // Reset the cursor and return the selected option.
            Console.CursorVisible = true;
            return selected;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            Assert.AreEqual("Hello!", console.Output);
        }
    }
}

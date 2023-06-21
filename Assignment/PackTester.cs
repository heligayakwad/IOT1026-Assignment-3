using System;

namespace Assignment
{
    /// <summary>
    /// A static class that provides a method to add equipment to a pack.
    /// </summary>
    public static class PackTester
    {
        /// <summary>
        /// Adds equipment to the specified pack based on user input.
        /// </summary>
        /// <param name="pack">The pack to add equipment to.</param>
        public static void AddEquipment(Pack pack)
        {
            bool addMoreItems = true;
            do
            {
                Console.WriteLine(pack); // Display the pack's contents

                Console.WriteLine("What do you want to add?");
                Console.WriteLine("1 - Arrow");
                Console.WriteLine("2 - Bow");
                Console.WriteLine("3 - Rope");
                Console.WriteLine("4 - Water");
                Console.WriteLine("5 - Food");
                Console.WriteLine("6 - Sword");
                Console.WriteLine("7 - Gather your pack and venture forth");

                try
                {
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        // Create the corresponding inventory item based on the user's choice
                        InventoryItem newItem = choice switch
                        {
                            1 => new Arrow(),
                            2 => new Bow(),
                            3 => new Rope(),
                            4 => new Water(),
                            5 => new Food(),
                            6 => new Sword(),
                            _ => null // Invalid choice, set newItem to null
                        };

                        if (newItem != null)
                        {
                            if (!pack.Add(newItem))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Could not fit this item into the pack.");
                            }
                        }
                        else if (choice == 7)
                        {
                            Console.WriteLine("Venturing Forth!");
                            addMoreItems = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("That is an invalid selection.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.ResetColor();
            } while (addMoreItems);
        }
    }
}

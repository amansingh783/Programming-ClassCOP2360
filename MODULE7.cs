using System;
using System.Collections.Generic;
using System.Linq;

namespace Module7DictionaryApp
{
    class Program
    {
        static void Main()
        {
            // Dictionary to store keys and a list of associated values
            Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();

            bool running = true;

            while (running)
            {
                // Display the menu
                Console.WriteLine("\nDictionary Menu:");
                Console.WriteLine("1. Populate the Dictionary");
                Console.WriteLine("2. Display Dictionary Contents");
                Console.WriteLine("3. Remove a Key");
                Console.WriteLine("4. Add a New Key and Value");
                Console.WriteLine("5. Add a Value to an Existing Key");
                Console.WriteLine("6. Sort the Keys");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option (1-7): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        // Populate the dictionary with some default values
                        myDictionary.Clear(); // Start fresh
                        myDictionary["Fruit"] = new List<string> { "Apple", "Banana", "Mango" };
                        myDictionary["Vegetables"] = new List<string> { "Carrot", "Broccoli" };
                        myDictionary["Drinks"] = new List<string> { "Water", "Tea" };
                        Console.WriteLine("Dictionary populated with default items.");
                        break;

                    case "2":
                        // Display the dictionary contents using foreach enumeration
                        if (myDictionary.Count == 0)
                        {
                            Console.WriteLine("The dictionary is empty.");
                        }
                        else
                        {
                            Console.WriteLine("Dictionary contents:");
                            foreach (KeyValuePair<string, List<string>> kvp in myDictionary)
                            {
                                Console.WriteLine($"Key: {kvp.Key}, Values: {string.Join(", ", kvp.Value)}");
                            }
                        }
                        break;

                    case "3":
                        // Remove a specified key
                        Console.Write("Enter the key to remove: ");
                        string removeKey = Console.ReadLine();
                        if (myDictionary.Remove(removeKey))
                        {
                            Console.WriteLine($"Key '{removeKey}' removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Key '{removeKey}' not found.");
                        }
                        break;

                    case "4":
                        // Add a new key and value
                        Console.Write("Enter the new key: ");
                        string newKey = Console.ReadLine();
                        Console.Write("Enter the value for this key: ");
                        string newValue = Console.ReadLine();

                        if (!myDictionary.ContainsKey(newKey))
                        {
                            myDictionary[newKey] = new List<string> { newValue };
                            Console.WriteLine($"Key '{newKey}' with value '{newValue}' added.");
                        }
                        else
                        {
                            Console.WriteLine($"Key '{newKey}' already exists. Use option 5 to add another value.");
                        }
                        break;

                    case "5":
                        // Add a value to an existing key
                        Console.Write("Enter the key to update: ");
                        string existingKey = Console.ReadLine();
                        if (myDictionary.ContainsKey(existingKey))
                        {
                            Console.Write("Enter the value to add: ");
                            string additionalValue = Console.ReadLine();
                            myDictionary[existingKey].Add(additionalValue);
                            Console.WriteLine($"Value '{additionalValue}' added to key '{existingKey}'.");
                        }
                        else
                        {
                            Console.WriteLine($"Key '{existingKey}' not found.");
                        }
                        break;

                    case "6":
                        // Sort the keys and display them
                        if (myDictionary.Count == 0)
                        {
                            Console.WriteLine("The dictionary is empty.");
                        }
                        else
                        {
                            Console.WriteLine("Sorted keys:");
                            foreach (var key in myDictionary.Keys.OrderBy(k => k))
                            {
                                Console.WriteLine(key);
                            }
                        }
                        break;

                    case "7":
                        running = false;
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose between 1 and 7.");
                        break;
                }
            }
        }
    }
}

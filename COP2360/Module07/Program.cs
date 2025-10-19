using System;
using System.Collections.Generic;
using System.Text.Json;


// Inventory dictionary Item (Logan's code)
public class  Item 
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"{Name} - Quantity: {Quantity}, Price: {Price:C}";
    }
}

class Program
{
    //Inventory dictionary (Logan's code)
    static Dictionary<string, Item> inventory = new Dictionary<string, Item>();

    static void Main(string[] args)
    {
        LoadInventory(); // Load inventory from file at the start

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nInventory Menu:");
            
            //Populates an item within the inventory
            Console.WriteLine("a. Populate Inventory with Basic Items");

            //Displays the contents of the inventory
            Console.WriteLine("b. Display Dictionary Contents");

            //Removes an item from the inventory
            Console.WriteLine("c. Remove a Key");

            //Searches for an item in the inventory
            Console.WriteLine("d. Add a New Key and Value");

            //Appends a value to an existing key
            Console.WriteLine("e. Append a Value to an Existing Key");

            //Sorts the inventory by key
            Console.WriteLine("f. Sort Inventory by Key");

            //Removes all items from the inventory (JESUS'S CODE)
            Console.WriteLine("g. Remove ALL items");

            //Saves the inventory to a file and exits the program
            Console.WriteLine("q. Quit");

          

            //records user input to determine which action to take
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                //Logan'S CODE
                case "a":
                    PopulateInventory();
                    break;
                //Tyler's CODE
                case "b":
                    DisplayInventory();
                    break;
                //Tyler's CODE
                case "c":
                    RemoveItem();
                    break;
                //Logan's CODE
                case "d":
                    AddInventoryItem();
                    break;
                //LJ's CODE
                case "e":
                    AppendInventoryItem();
                    break;
                case "f":
                    SortInventory();
                    break;
                //JESUS'S CODE
                case "g":
                    ClearAllItems();
                    break;
                case "q":
                    SaveInventory();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        
    }

    //Saves the inventory to a file
    static void SaveInventory()
    {
        string json = JsonSerializer.Serialize(inventory, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("inventory.json", json);
        Console.WriteLine("Inventory saved to file.");
    }

    //Loads the inventory from a file
    static void LoadInventory()
    {
        if (File.Exists("inventory.json"))
        {
            string json = File.ReadAllText("inventory.json");
            inventory = JsonSerializer.Deserialize<Dictionary<string, Item>>(json) ?? new Dictionary<string, Item>();
            Console.WriteLine("Inventory loaded from file.");
        }

        else
        {
            Console.WriteLine("No saved inventory file found. Starting with an empty inventory.");
        }
    }

    //Populates the inventory with sample items (for testing purposes)
    static void PopulateInventory()
    {
        //I ended up really getting stuck on produce items when I was thinking of items to add
        //I was probably hungry
        inventory = new Dictionary<string, Item>
        {
            { "Apples", new Item { Name = "Apples", Quantity = 100, Price = 0.50m } },
            { "Bananas", new Item { Name = "Bananas", Quantity = 120, Price = 0.30m } },
            { "Oranges", new Item { Name = "Oranges", Quantity = 80, Price = 0.60m } },
            { "Lettuce", new Item { Name = "Lettuce", Quantity = 40, Price = 1.25m } },
            { "Tomatoes", new Item { Name = "Tomatoes", Quantity = 75, Price = 0.90m } },
            { "Carrots", new Item { Name = "Carrots", Quantity = 60, Price = 0.40m } },
            { "Potatoes", new Item { Name = "Potatoes", Quantity = 200, Price = 0.35m } },
            { "Onions", new Item { Name = "Onions", Quantity = 150, Price = 0.45m } },
            { "Cucumbers", new Item { Name = "Cucumbers", Quantity = 50, Price = 0.70m } },
            { "Bell Peppers", new Item { Name = "Bell Peppers", Quantity = 30, Price = 1.10m } }
        };
        Console.WriteLine("Inventory populated with sample items.");
    }

    //Adds a singular inventory item
    static void AddInventoryItem()
    {

        string name = "";
        int quantity = 0;
        decimal price = 0;

        try
        {
            Console.Write("Enter item name: ");
            name = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Item name cannot be empty.");
            
        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return;
        }

        try
        {
            Console.Write("Enter quantity of item: ");
            string quantityInput = Console.ReadLine();
            if (!int.TryParse(quantityInput, out quantity))
            {
                throw new FormatException("Invalid quantity. Please enter a whole number.");
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return;
        }

        try 
        {
            Console.Write("Enter price of item: ");
            string priceInput = Console.ReadLine();
            if (!decimal.TryParse(priceInput, out price))
                    throw new FormatException("Invalid price. Please enter a valid decimal number.");
        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return;
        }


        inventory[name] = new Item { Name = name, Quantity = quantity, Price = price };
        Console.WriteLine($"{name} added to inventory.");
    }

    //Displays the contents of the inventory (Tyler's code)
    static void DisplayInventory()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Console.WriteLine("\nCurrent Inventory:");
        foreach (var item in inventory)
        {
            Console.WriteLine(item.Value);
        }
    }

    //Removes an item from the inventory (Tyler's code)
    static void RemoveItem()
    {
        Console.Write("Enter the item name to remove: ");
        string name = Console.ReadLine();

        if (inventory.Remove(name))
        {
            Console.WriteLine($"{name} was removed from inventory.");
        }
        else
        {
            Console.WriteLine($"{name} not found in inventory.");
        }
    }

    //Removes ALL items from the inventory (JESUS'S CODE)
    static void ClearAllItems()
    {
        inventory.Clear();
        Console.WriteLine("All inventory items have been removed.");
    }


    //Appends a value to an existing key (LJ's CODE)
    static void AppendInventoryItem()
    {
        {
            Console.Write("Enter the item name to append: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Item name cannot be empty.");
                return;
            }

            if (inventory.ContainsKey(name))
            {
                try
                {
                    Console.Write("Enter new quantity: ");
                    string quantityInput = Console.ReadLine();
                    if (!int.TryParse(quantityInput, out int addQuantity) || addQuantity < 0)
                    {
                        Console.WriteLine("Invalid quantity. Please enter a non-negative number.");
                        return;
                    }

                    Console.Write("Enter new price for the item: ");
                    string priceInput = Console.ReadLine();
                    if (!decimal.TryParse(priceInput, out decimal newPrice) || newPrice < 0)
                    {
                        Console.WriteLine("Invalid price. Please enter a valid positive decimal value.");
                        return;
                    }

                    inventory[name].Quantity = addQuantity;
                    inventory[name].Price = newPrice;

                    Console.WriteLine($"✅ {name} updated successfully!");
                    Console.WriteLine($"New Quantity: {inventory[name].Quantity}");
                    Console.WriteLine($"New Price: {inventory[name].Price:C}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while updating: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"❌ Item '{name}' not found in inventory.");
            }

        }
    }

    //Sorts the inventory by key (Jayzalee's CODE)
    static void SortInventory()
    {
        Console.WriteLine("Yet to be Implemented");
    }
}







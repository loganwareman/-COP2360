using System;
using System.Collections.Generic;

// Inventory dictionary
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

    static Dictionary<string, Item> inventory = new Dictionary<string, Item>();

    static void Main(string[] args)
    {

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nInventory Menu:");
            
            //Populates an item within the inventory
            Console.WriteLine("a. Insert Inventory Item");
            
            Console.WriteLine("b. Display Dictionary Contents");

            Console.WriteLine("c. Remove a Key");
            
            Console.WriteLine("q. Quit");
            
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "a":
                    PopulateInventory();
                    break;
                case "b":
                    //DisplayInventory();
                    break;
                case "c":
                    //RemoveItem();
                    break;
                case "q":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        
    }

    //Populates the inventory with an item
    static void PopulateInventory()
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




}
    

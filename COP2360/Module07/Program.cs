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
        }

        switch (choice)
        {
            case "a":
                PopulateInventory();
                break;
            case "b":
                DisplayInventory();
                break;
            case "c":
                RemoveItem();
                break;
            case "q":
                running = false;
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }

    static void PopulateInventory()
    {
        Console.Write("Enter item name: ");
        string name = Console.ReadLine();

        Console.Write("Enter quantity of item: ")
        int quantity = int.Parse(Console.ReadLine());

        Console.Write("Enter price of item: ")
        double price = double.Parse(Console.ReadLine());

        inventory[name] = new Item { Name = name, Quantity = quantity, Price = price };
        Console.WriteLine($"{name} added to inventory.");
    }




}
    

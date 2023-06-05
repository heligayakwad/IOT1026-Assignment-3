using System;
using System.Collections.Generic;

public class Pack
{
  private List<InventoryItem> items;  // List to store the inventory items in the pack
    private int maxCount;               // Maximum number of items allowed in the pack
    private int maxVolume;              // Maximum volume allowed in the pack
    private int maxWeight;              // Maximum weight allowed in the pack

    public Pack(int maxCount, int maxVolume, int maxWeight)
    {
        this.maxCount = maxCount;
        this.maxVolume = maxVolume;
        this.maxWeight = maxWeight;

        items = new List<InventoryItem>(); // Initialize the list of items
    }
// Adds an inventory item to the pack if it satisfies the constraints
    public bool Add(InventoryItem item)
    {
        if (items.Count < maxCount && GetTotalVolume() + item.Volume <= maxVolume && GetTotalWeight() + item.Weight <= maxWeight)
        {
            items.Add(item);
            return true;
        }
        else
        {
            return false;
        }
    }
// Removes an inventory item from the pack
    public void Remove(InventoryItem item)
    {
        items.Remove(item);
    }

    public string ToString()
    {
        string result = $"Pack contains {items.Count} items with total weight {GetTotalWeight()} and volume {GetTotalVolume()}:\n";
        
        foreach (var item in items)
        {
            result += $"- {item.Name} ({item.Weight} kg, {item.Volume} L)\n";
        }

        return result;
    }
// Calculates the total volume of all items in the pack
    private float GetTotalVolume()
    {
        float totalVolume = 0f;

        foreach (var item in items)
        {
            totalVolume += item.Volume;
        }

        return totalVolume;
     }

     private float GetTotalWeight()
     {
         float totalWeight = 0f;

         foreach (var item in items)
         {
             totalWeight += item.Weight;
         }

         return totalWeight;
     }
}
// Abstract base class representing an inventory item
public abstract class InventoryItem
{
    public string Name { get; set; } // Name of the inventory item
    public float Weight { get; set; } // Weight of the inventory item in kg
    public float Volume { get; set; } // Volume of the inventory item in liters


    public InventoryItem(string name, float weight, float volume)
    {
        Name = name;
        Weight = weight;
        Volume = volume;
    }
}
// Concrete classes representing specific inventory items
public class Arrow : InventoryItem
{
    public Arrow() : base("Arrow", 0.1f, 0.05f) {}
}

public class Bow : InventoryItem
{
    public Bow() : base("Bow", 1f, 4f) {}
}

public class Rope : InventoryItem
{
    public Rope() : base("Rope", 1f, 1.5f) {}
}

public class Water : InventoryItem
{
    public Water() : base("Water", 2f, 3f) {}
}

public class Food : InventoryItem
{
    public Food() : base("Food", 1f, 0.5f) {}
}

public class Sword : InventoryItem
{
   public Sword() : base("Sword", 5f, 3f) {}
}

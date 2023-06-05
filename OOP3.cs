using System;
using System.Collections.Generic;

public class Pack
{
    private List<InventoryItem> items;
    private int maxCount;
    private int maxVolume;
    private int maxWeight;

    public Pack(int maxCount, int maxVolume, int maxWeight)
    {
        this.maxCount = maxCount;
        this.maxVolume = maxVolume;
        this.maxWeight = maxWeight;

        items = new List<InventoryItem>();
    }

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

public abstract class InventoryItem
{
    public string Name { get; set; }
    public float Weight { get; set; }
    public float Volume { get; set; }

    public InventoryItem(string name, float weight, float volume)
    {
        Name = name;
        Weight = weight;
        Volume = volume;
    }
}

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

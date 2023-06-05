public class InventoryItem
{
    public string Name { get; }
    public double Weight { get; }
    public double Volume { get; }

    public InventoryItem(string name, double weight, double volume)
    {
        Name = name;
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base("Arrow", 0.1, 0.05)
    {
    }
}

public class Bow : InventoryItem
{
    public Bow() : base("Bow", 1, 4)
    {
    }
}

public class Rope : InventoryItem
{
    public Rope() : base("Rope", 1, 1.5)
    {
    }
}

public class Water : InventoryItem
{
    public Water() : base("Water", 2, 3)
    {
    }
}

public class Food : InventoryItem
{
    public Food() : base("Food", 1, 0.5)
    {
    }
}

public class Sword : InventoryItem
{
    public Sword() : base("Sword", 5, 3)
    {
    }
}
using System;
using System.Collections.Generic;

public class Pack
{
    private int maxCount;
    private double maxVolume;
    private double maxWeight;
    private List<InventoryItem> items;

    public Pack(int maxCount, double maxVolume, double maxWeight)
    {
        this.maxCount = maxCount;
        this.maxVolume = maxVolume;
        this.maxWeight = maxWeight;
        items = new List<InventoryItem>();
    }

    public bool AddItem(InventoryItem item)
    {
        if (items.Count >= maxCount)
            return false;

        double totalVolume = CalculateTotalVolume() + item.Volume;
        double totalWeight = CalculateTotalWeight() + item.Weight;

        if (totalVolume > maxVolume || totalWeight > maxWeight)
            return false;

        items.Add(item);
        return true;
    }

    public override string ToString()
    {
        string packInfo = $"Pack: Max Count: {maxCount}, Max Volume: {maxVolume}, Max Weight: {maxWeight}\n";
        string itemInfo = "Items:\n";

        foreach (InventoryItem item in items)
        {
            itemInfo += $"- {item.Name}: Weight: {item.Weight}, Volume: {item.Volume}\n";
        }

        return packInfo + itemInfo;
    }

    private double CalculateTotalVolume()
    {
        double totalVolume = 0;

        foreach (InventoryItem item in items)
        {
            totalVolume += item.Volume;
        }

        return totalVolume;
    }

    private double CalculateTotalWeight()
    {
        double totalWeight = 0;

        foreach (InventoryItem item in items)
        {
            totalWeight += item.Weight;
        }

        return totalWeight;
    }
}

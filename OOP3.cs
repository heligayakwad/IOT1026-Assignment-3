using System;
using System.Collections.Generic;

/// <summary>
/// Represents a pack that can hold inventory items with specific constraints.
/// </summary>
public class Pack
{
    private List<InventoryItem> items;
    private int maxCount;
    private int maxVolume;
    private int maxWeight;

    /// <summary>
    /// Initializes a new instance of the <see cref="Pack"/> class with the specified constraints.
    /// </summary>
    /// <param name="maxCount">The maximum number of items allowed in the pack.</param>
    /// <param name="maxVolume">The maximum volume allowed in the pack.</param>
    /// <param name="maxWeight">The maximum weight allowed in the pack.</param>
    public Pack(int maxCount, int maxVolume, int maxWeight)
    {
        this.maxCount = maxCount;
        this.maxVolume = maxVolume;
        this.maxWeight = maxWeight;

        items = new List<InventoryItem>();
    }

    /// <summary>
    /// Adds an inventory item to the pack if it satisfies the constraints.
    /// </summary>
    /// <param name="item">The inventory item to add.</param>
    /// <returns><c>true</c> if the item was successfully added; otherwise, <c>false</c>.</returns>
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

    /// <summary>
    /// Removes an inventory item from the pack.
    /// </summary>
    /// <param name="item">The inventory item to remove.</param>
    public void Remove(InventoryItem item)
    {
        items.Remove(item);
    }

    /// <summary>
    /// Returns a string representation of the pack and its contents.
    /// </summary>
    /// <returns>A string representation of the pack.</returns>
    public override string ToString()
    {
        string result = $"Pack contains {items.Count} items with total weight {GetTotalWeight()} and volume {GetTotalVolume()}:\n";
        
        foreach (var item in items)
        {
            result += $"- {item.Name} ({item.Weight} kg, {item.Volume} L)\n";
        }

        return result;
    }

    /// <summary>
    /// Calculates the total volume of all items in the pack.
    /// </summary>
    /// <returns>The total volume of all items in the pack.</returns>
    private float GetTotalVolume()
    {
        float totalVolume = 0f;
        foreach (var item in items)
        {
            totalVolume += item.Volume;
        }
        return totalVolume;
    }

    /// <summary>
    /// Calculates the total weight of all items in the pack.
    /// </summary>
    /// <returns>The total weight of all items in the pack.</returns>
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

/// <summary>
/// Represents an inventory item.
/// </summary>
public abstract class InventoryItem
{
    /// <summary>
    /// Gets or sets the name of the inventory item.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
   

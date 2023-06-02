namespace JewelCollector;

/// <summary>
/// Represents a water item in the game.
/// </summary>
public class Water : Item {

    /// <summary>
    /// Initializes a new instance of the <see cref="Water"/> class with the specified position, symbol and whether the item is transpassable or collectable.
    /// </summary>
    /// <param name="xPosition">The X position of the water.</param>
    /// <param name="yPosition">The Y position of the water.</param>
    public Water(int xPosition, int yPosition) : base(xPosition, yPosition, "##", false, false) {}
}

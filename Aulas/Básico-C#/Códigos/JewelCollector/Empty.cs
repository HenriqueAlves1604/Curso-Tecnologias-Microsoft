namespace JewelCollector;

/// <summary>
/// Represents an empty item in the game.
/// </summary>
public class Empty : Item {

    /// <summary>
    /// Initializes a new instance of the <see cref="Empty"/> class with the specified position, symbol and whether the item is transpassable or collectable.
    /// </summary>
    /// <param name="xPosition">The X position of the green jewel.</param>
    /// <param name="yPosition">The Y position of the green jewel.</param>
    public Empty(int xPosition, int yPosition) : base(xPosition, yPosition, "--", true, false) {}
}

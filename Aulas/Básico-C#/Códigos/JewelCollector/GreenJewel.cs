namespace JewelCollector;

/// <summary>
/// Represents a green jewel in the game.
/// </summary>
public class GreenJewel : Jewel {
    private static readonly int VALUE = 50;

    /// <summary>
    /// Initializes a new instance of the <see cref="GreenJewel"/> class with the specified position, symbol and value of the jewel.
    /// </summary>
    /// <param name="xPosition">The X position of the green jewel.</param>
    /// <param name="yPosition">The Y position of the green jewel.</param>
    public GreenJewel(int xPosition, int yPosition) : base (xPosition, yPosition, "JG", VALUE) {}
}

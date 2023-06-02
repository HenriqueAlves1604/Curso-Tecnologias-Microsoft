namespace JewelCollector;

/// <summary>
/// Represents a red jewel in the game.
/// </summary>
public class RedJewel : Jewel {
    private static readonly int VALUE = 100;

    /// <summary>
    /// Initializes a new instance of the <see cref="RedJewel"/> class with the specified position, symbol and value of the jewel.
    /// </summary>
    /// <param name="xPosition">The X position of the green jewel.</param>
    /// <param name="yPosition">The Y position of the green jewel.</param>
    public RedJewel(int xPosition, int yPosition) : base (xPosition, yPosition, "JR", VALUE) {}
}
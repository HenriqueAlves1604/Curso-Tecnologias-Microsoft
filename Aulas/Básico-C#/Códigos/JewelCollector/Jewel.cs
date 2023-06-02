namespace JewelCollector;
/// <summary>
/// Represents a jewel item in the game.
/// </summary>
public class Jewel : Item {
    /// <summary>
    /// Gets or sets the value of the jewel.
    /// </summary>
    public int value {get; set;} 

    /// <summary>
    /// Initializes a new instance of the <see cref="Jewel"/> class.
    /// </summary>
    /// <param name="xPosition">The X position of the jewel.</param>
    /// <param name="yPosition">The Y position of the jewel.</param>
    /// <param name="type">The type of the jewel.</param>
    /// <param name="value">The value of the jewel.</param>
    public Jewel(int xPosition, int yPosition, string type, int value) : base (xPosition, yPosition, type, false, true) {
        this.value = value;
    }
}
namespace JewelCollector;

/// <summary>
/// Represents an item in the map of the game.
/// </summary>
public class Item {
    /// <summary>
    /// Gets or sets the X position of the item.
    /// </summary>
    public int xPosition {get; set;}

    /// <summary>
    /// Gets or sets the Y position of the item.
    /// </summary>
    public int yPosition {get; set;}

    /// <summary>
    /// Gets the symbol representing the item.
    /// </summary>
    public string symbol {get;}

    /// <summary>
    /// Gets or sets a value indicating whether the item is transpassable.
    /// </summary>
    public bool transpassable {get; set;}

    /// <summary>
    /// Gets or sets a value indicating whether the item is collectable.
    /// </summary>
    public bool collectable {get; set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="Item"/> class.
    /// </summary>
    /// <param name="xPosition">The X position of the item.</param>
    /// <param name="yPosition">The Y position of the item.</param>
    /// <param name="symbol">The symbol representing the item.</param>
    /// <param name="transpassable">A value indicating whether the item is transpassable.</param>
    /// <param name="collectable">A value indicating whether the item is collectable.</param>
    public Item(int xPosition, int yPosition, string symbol, bool transpassable, bool collectable) {
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.symbol = symbol;
        this.transpassable = transpassable;
        this.collectable = collectable;
    }

    /// <summary>
    /// Returns a string representation of the item.
    /// </summary>
    /// <returns>The symbol representing the item.</returns>
    public override string ToString() {
        return symbol;
    }
}
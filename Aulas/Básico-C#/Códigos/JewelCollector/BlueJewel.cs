namespace JewelCollector;

/// <summary>
/// Represents a red jewel in the game.
/// </summary>
public class BlueJewel : Jewel, IEnergizable {
    private static readonly int VALUE = 10;
    private Robot robot{get; set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="BlueJewel"/> class with the specified position, symbol and value of the jewel.
    /// </summary>
    /// <param name="xPosition">The X position of the green jewel.</param>
    /// <param name="yPosition">The Y position of the green jewel.</param>
    public BlueJewel(int xPosition, int yPosition, Robot robot) : base ( xPosition, yPosition, "JB", VALUE) {
        this.robot = robot;
    }

    /// <summary>
    /// Updates the energy of the robot that interacts with the blue jewel.
    /// </summary>
    public void updateEnergy() {
        robot.energy += 5;
    }
}
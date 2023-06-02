namespace JewelCollector;

/// <summary>
/// Represents a tree item in the game, which provides energy to the robot.
/// </summary>
public class Tree : Item, IEnergizable {
    /// <summary>
    /// Gets or sets the robot associated with the tree.
    /// </summary>
    private Robot robot{get; set;}
    
    /// <summary>
    /// Gets or sets a value indicating whether the tree has been used.
    /// </summary>
    private bool used{get; set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="Tree"/> class with the specified position, symbol and whether the item is transpassable or collectable.
    /// </summary>
    /// <param name="xPosition">The X position of the tree.</param>
    /// <param name="yPosition">The Y position of the tree.</param>
    /// <param name="robot">The robot associated with the tree.</param> 
    public Tree(int xPosition, int yPosition, Robot robot) : base(xPosition, yPosition, "$$", false, false) {
        this.robot = robot;
        this.used = false;
    }

    /// <summary>
    /// Updates the energy of the robot that interacts with the tree.
    /// </summary>
    public void updateEnergy(){
        if(!used){
            robot.energy += 3;
            this.used = true;
        }
    }
}

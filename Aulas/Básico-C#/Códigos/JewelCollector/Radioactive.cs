namespace JewelCollector;

/// <summary>
/// Represents a radioactive item in the game.
/// </summary>
public class Radioactive : Item {

    /// <summary>
    /// Initializes a new instance of the <see cref="Radioactive"/> class with the specified position, symbol and whether the item is transpassable or collectable.
    /// </summary>
    /// <param name="xPosition">The X position of the radioactive item.</param>
    /// <param name="yPosition">The Y position of the radioactive item.</param>
    public Radioactive(int xPosition, int yPosition) : base (xPosition, yPosition, "!!", true, false){}

    /// <summary>
    /// Updates the energy of the robot based on the presence of radioactive items next to the robot.
    /// </summary>
    /// <param name="map">The map containing the robot and the items.</param>
    public static void updateEnergy(Map map){
        int x = map.robot.xPosition;
        int y = map.robot.yPosition;
        if(map.map[y][x] is Radioactive){
            map.robot.energy -= 30;
        }
        try{
            if(map.map[y + 1][x] is Radioactive){
            map.robot.energy -= 10;
            }
        }   catch(IndexOutOfRangeException){}

        try{
            if(map.map[y - 1][x] is Radioactive){
            map.robot.energy -= 10;
            }
        }   catch(IndexOutOfRangeException){}

        try{
            if(map.map[y][x + 1] is Radioactive){
            map.robot.energy -= 10;
            }
        }   catch(IndexOutOfRangeException){}

        try{
            if(map.map[y][x - 1] is Radioactive){
            map.robot.energy -= 10;
            }
        }   catch(IndexOutOfRangeException){}

    }



}

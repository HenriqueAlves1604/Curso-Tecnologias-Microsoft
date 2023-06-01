namespace JewelCollector;

public class BlueJewel : Jewel, IEnergizable {
    private static readonly int VALUE = 10;
    private Robot robot;

    //Constructor:
    public BlueJewel(int xPosition, int yPosition, Robot robot) : base ( xPosition, yPosition, "JB", VALUE) {
        this.robot = robot;
    }

    public void updateEnergy() {
        robot.energy += 5;
    }
}
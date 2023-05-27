namespace JewelCollector;

public class BlueJewel : Jewel, ICollectable {
    private static readonly int VALUE = 10;

    //Constructor:
    public BlueJewel(int xPosition, int yPosition) : base ( xPosition, yPosition, "JB", VALUE) {}

    public void collect() {

    }
}
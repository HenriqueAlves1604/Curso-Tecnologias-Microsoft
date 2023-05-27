namespace JewelCollector;

public class RedJewel : Jewel {
    private static readonly int VALUE = 100;

    //Constructor:
    public RedJewel(int xPosition, int yPosition) : base ("JR", xPosition, yPosition, VALUE) {
    }
}
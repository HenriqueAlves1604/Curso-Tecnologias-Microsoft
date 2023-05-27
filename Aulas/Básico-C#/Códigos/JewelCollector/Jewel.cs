namespace JewelCollector;

public class Jewel : Item {
    public int value {get; set;} 
    public Jewel(int xPosition, int yPosition, string type, int value) : base (xPosition, yPosition, type, false, true) {
        this.value = value;
    }
}
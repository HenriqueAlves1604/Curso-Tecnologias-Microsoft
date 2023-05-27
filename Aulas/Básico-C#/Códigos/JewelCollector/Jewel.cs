namespace JewelCollector;

public class Jewel : Item{
    private string type = "";
    private int xPosition;
    private int yPosition;
    private readonly int value; 

    //Constructor:
    public Jewel(string type, int xPosition, int yPosition, int value) : base(type, false, true) {
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.value = value;
    }

    //Gets and sets:

    public int getXPosition() {
        return this.xPosition;
    }

    public void setXPosition(int xPosition){
        this.xPosition = xPosition;
    }

    public int getYPosition() {
        return this.yPosition;
    }

    public void setYPosition(int yPosition){
        this.yPosition = yPosition;
    }
    public int getValue() {
        return this.value;
    }

}

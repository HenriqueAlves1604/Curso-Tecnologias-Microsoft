namespace JewelCollector;

public class Empty : Item {
    private int xPosition;
    private int yPosition;

    //Constructor:
    public Empty(int xPosition, int yPosition) : base("--", true, false){
        this.xPosition = xPosition;
        this.yPosition = yPosition;
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
}

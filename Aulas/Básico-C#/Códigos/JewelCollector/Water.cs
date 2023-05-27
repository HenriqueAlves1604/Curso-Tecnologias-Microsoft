namespace JewelCollector;

public class Water : Item {
    private int xPosition;
    private int yPosition;

    //Constructor:
    public Water(int xPosition, int yPosition) : base("##"){
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

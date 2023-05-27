namespace JewelCollector;

public class Tree : Item {
    private int xPosition;
    private int yPosition;

    //Constructor:
    public Tree(int xPosition, int yPosition) : base("$$", false, false){
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

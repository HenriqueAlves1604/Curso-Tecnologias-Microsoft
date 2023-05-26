namespace JewelCollector;

public class Obstacle {
    private string type;
    private int xPosition;
    private int yPosition;

    //Constructor:
    public Obstacle(string type, int xPosition, int yPosition){
        this.type = type;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
    }

    //Gets and sets:
    public string getType() {
        return this.type;
    }

    public void setType(string type){
        this.type = type;
    }

    public int getXPosition() {
        return this.xPosition;
    }

    public void setXPosition(int yPosition){
        this.yPosition = yPosition;
    }

    public int getYPosition() {
        return this.xPosition;
    }

    public void setYPosition(int yPosition){
        this.yPosition = yPosition;
    }
}

namespace JewelCollector;

public class Obstacle
{
    private string type {get; set;}
    private int xPosition {get; set;}
    private int yPosition {get; set;}

    //Constructor:
    Obstacle(string type, int xPosition, int yPosition){
        this.type = type;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
    }

}
